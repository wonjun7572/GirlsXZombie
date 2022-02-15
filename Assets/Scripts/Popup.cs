using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Button Btn;

   

    public GameObject Rank;

    public void OnClick()
    {
        Rank.SetActive(true);
    }

    public void OnClickOff()
    {
        Rank.SetActive(false);
    }
}
