using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void ChangeGameScene()
    {
      LoadingSceneController.LoadScene("2048");
    }
}
