using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool IsPause;

    /// <summary>
    /// 로딩씬 컨트롤러를 이용한 메뉴씬 호출
    /// </summary>
    public void Load_MenuScene()
    {
        LoadingSceneController.LoadScene("MenuScene");
    }

    /// <summary>
    /// 로딩씬 컨트롤러를 이용한 스테이지1씬 호출
    /// </summary>
    public void Load_Stage1Scene()
    {
        LoadingSceneController.LoadScene("2048");
    }

    /// <summary>
    /// 게임 일시정지
    /// </summary>
    public void Pause_Game()
    {
        GameObject.Find("PausePanel").GetComponent<UIScreenDisplay>().Show();
        StopTime();
    }

    /// <summary>
    /// 게임 일시정지 해제 후 재 시작
    /// </summary>
    public void Resume_Game()
    {
        GameObject.Find("PausePanel").GetComponent<UIScreenDisplay>().Hide();
        PlayTime();
    }

    public void GameOption_ON()
    {
        GameObject.Find("OptionPanel").GetComponent<UIScreenDisplay>().Show();
    }

    public void GameOption_OFF()
    {
        GameObject.Find("OptionPanel").GetComponent<UIScreenDisplay>().Hide();
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void PlayTime()
    {
        Time.timeScale = 1f;
    }
}
