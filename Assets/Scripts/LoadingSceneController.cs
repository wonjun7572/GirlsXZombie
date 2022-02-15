using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    Image ProgressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }
    
    IEnumerator LoadSceneProcess()
    {
      AsyncOperation op =  SceneManager.LoadSceneAsync(nextScene);

      op.allowSceneActivation = false;

        float timer = 0f; //이거 늘리면 로딩시간 늘어짐

        while(!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                ProgressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                ProgressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(ProgressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }//fake 로딩시간
            }
        }
    }
}
