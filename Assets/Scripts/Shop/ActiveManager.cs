using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    public List<GameObject> Active_Btn = new List<GameObject>();

    public GameObject option;
    public GameObject ranking;
    public GameObject creater;

    public void Active0_true()
    {
        for(int i=0; i<Active_Btn.Count; i++)
        {
            Active_Btn[i].SetActive(true);
        }   
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    public void Active0_false()
    {
        for (int i = 0; i < Active_Btn.Count; i++)
        {
            Active_Btn[i].SetActive(false);
        }
    }

    public void OptionPopUp()
    {
        option.SetActive(true);
    }

    public void RankingPopUp()
    {
        ranking.SetActive(true);
    }

    public void CreaterPopUp()
    {
        creater.SetActive(true);
    }
}
