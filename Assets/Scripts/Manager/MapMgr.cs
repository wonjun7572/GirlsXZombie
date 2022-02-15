using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour
{
    public GameObject ExistLabMapPanel;
    public GameObject LabMapPanel;
    public GameObject BeforeBuyLabMapPanel;
    public GameObject MaybeBasicMapPanel;
    public GameObject BasicMapPanel;

    public void Lab_MapKeyChange()
    {
        // 0 일때가 기본 맵
        // 1 일때가 연구실 맵
        if (PlayerPrefsMgr._map == 1)
        {
            Debug.Log("이미 연구실 맵이 적용되었습니다");
            ExistLabMapPanel.SetActive(true);
        }

        else if (PlayerPrefsMgr._lab == 1)
        {
            PlayerPrefsMgr._map = 1;
            Debug.Log("연구실 맵이 적용되었습니다");
            Debug.Log(PlayerPrefsMgr._map);
            LabMapPanel.SetActive(true);
        }


        else
        {
            Debug.Log("연구실맵을 먼저 구매해 주세요");
            BeforeBuyLabMapPanel.SetActive(true);
        }
    }

    public void Basic_MapKeyChange()
    {
        if(PlayerPrefsMgr._map == 0)
        {
            Debug.Log("이미 기본 맵이 적용되었습니다");
            MaybeBasicMapPanel.SetActive(true);
        }

        else
        {
            PlayerPrefsMgr._map = 0;
            Debug.Log("기본 맵이 적용되었습니다");
            BasicMapPanel.SetActive(true);
        }
    }
}
