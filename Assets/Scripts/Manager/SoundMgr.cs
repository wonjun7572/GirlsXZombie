using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMgr : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource bgSound;
    public AudioClip[] bgList;

    //public Slider sound;
    //public Slider bgsound;
    //public Slider sfxsound;

    public static SoundMgr instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i<bgList.Length; i++)
        {
            // 씬 이름 == clip 이름
            if(arg0.name == bgList[i].name)
            {
                BgSoundPlay(bgList[i]);
            }
        }
    }

    public void BGSoundVolume(float val)
    {
        // 파라미터 값과 실수형 값을 넘겨줌, 이때 넘겨주는 값이 볼륨의 값이 됨
        // 믹스의 볼륨은 로그 스케일을 사용하므로, 간단한 식을 통하여 변환한 값을 넣어줘야 제대로 음량이 변화됨
        mixer.SetFloat("BGSoundVolume", Mathf.Log10(val) * 20);
    }

    public void MasterSoundVolume(float val)
    {
        // 파라미터 값과 실수형 값을 넘겨줌, 이때 넘겨주는 값이 볼륨의 값이 됨
        // 믹스의 볼륨은 로그 스케일을 사용하므로, 간단한 식을 통하여 변환한 값을 넣어줘야 제대로 음량이 변화됨
        mixer.SetFloat("MasterSoundVolume", Mathf.Log10(val) * 20);
    }

    public void SFXSoundVolume(float val)
    {
        // 파라미터 값과 실수형 값을 넘겨줌, 이때 넘겨주는 값이 볼륨의 값이 됨
        // 믹스의 볼륨은 로그 스케일을 사용하므로, 간단한 식을 통하여 변환한 값을 넣어줘야 제대로 음량이 변화됨
        mixer.SetFloat("SFXSoundVolume", Mathf.Log10(val) * 20);
    }

    // 효과음
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>(); // 사운드 재생을 위한 Audio 컴포넌트 생성
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go, clip.length);
    }

    // BGM 백그라운드
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGSound")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 1.0f;
        bgSound.Play();
    }
}
