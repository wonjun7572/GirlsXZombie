using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void GoMap()
    {
        LoadingSceneController.LoadScene("2048");
        Spawner.Instance.getgoldcheck = false;
        StageMgr.StageCount = 0;
    }
}
