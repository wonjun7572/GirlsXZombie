using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySkin : MonoBehaviour
{
    public GameObject BuySuccess;
    public GameObject BuyFail;
    public GameObject PopupPanel;
    public GameObject ExistMap;

    public void BuyLabmapSkin()
    {
        PopupPanel.SetActive(false);
        if(PlayerPrefsMgr._gold >= 50 && PlayerPrefsMgr._lab == 0)
        {
            PlayerPrefsMgr._gold -= 50;
            PlayerPrefsMgr._lab = 1;
            BuySuccess.SetActive(true);

            Debug.Log(PlayerPrefsMgr._lab);
        }

        else if (PlayerPrefsMgr._lab == 1)
        {
            ExistMap.SetActive(true);
        }

        else
        {
            BuyFail.SetActive(true);
        }
    }

}
