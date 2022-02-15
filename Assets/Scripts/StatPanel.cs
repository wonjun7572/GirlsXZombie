using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    public GameObject Stat;

    public void Onclick()
    {
        Stat.SetActive(true);
    }

    public void OffClick()
    {
        Stat.SetActive(false);
    }
}
