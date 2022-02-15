using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Bt_retry()
    {
        SceneManager.UnloadSceneAsync(4);
        Debug.Log("안녕하세요");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
