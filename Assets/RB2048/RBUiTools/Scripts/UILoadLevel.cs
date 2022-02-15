using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoadLevel : MonoBehaviour
{

    public static string nextScene;

    public Slider progressBar;
    public Text loadtext;
    public Button Playbtn;

    private bool btnDown = false;

    private void Start()
    {
        StartCoroutine("LoadScene");
    }
   
    public void ButtonDown()
    {
        btnDown = true;
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync("MenuScene");

        op.allowSceneActivation = false;

        Playbtn.gameObject.SetActive(false);

        while (!op.isDone)

        {
            yield return null;

            if(progressBar.value <1f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 1f, Time.deltaTime);
            }
            else
            {
                loadtext.text = "PLAY 버튼을 누르세요";
                Playbtn.gameObject.SetActive(true);
            }

            if(progressBar.value>=1f && op.progress >=0.9f && btnDown == true)
            {
                op.allowSceneActivation = true;
            }
        }
    }
}

