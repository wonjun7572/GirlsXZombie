using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResult : MonoBehaviour
{
    private static ShowResult instance;

    public static ShowResult Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // 소녀 이미지 순서대로 D C B A S
    public GameObject[] GirlImage;

    // 별 이미지 순서대로 1 2
    public GameObject[] StarList;

    public void Show_D_1()
    {
        GirlImage[0].SetActive(true);
        StarList[0].SetActive(true);
    }

    public void Show_D_2()
    {
        GirlImage[0].SetActive(true);
        StarList[1].SetActive(true);
    }

    public void Show_C_1()
    {
        GirlImage[1].SetActive(true);
        StarList[0].SetActive(true);
    }

    public void Show_C_2()
    {
        GirlImage[1].SetActive(true);
        StarList[1].SetActive(true);
    }

    public void Show_B_1()
    {
        GirlImage[2].SetActive(true);
        StarList[0].SetActive(true);
    }

    public void Show_B_2()
    {
        GirlImage[2].SetActive(true);
        StarList[1].SetActive(true);
    }

    public void Show_A_1()
    {
        GirlImage[3].SetActive(true);
        StarList[0].SetActive(true);
    }

    public void Show_A_2()
    {
        GirlImage[3].SetActive(true);
        StarList[1].SetActive(true);
    }

    public void Show_S_1()
    {
        GirlImage[4].SetActive(true);
        StarList[0].SetActive(true);
    }

    public void Show_S_2()
    {
        GirlImage[4].SetActive(true);
        StarList[1].SetActive(true);
    }
}
