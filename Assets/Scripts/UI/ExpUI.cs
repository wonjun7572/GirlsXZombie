using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    public Text expText;

    // Update is called once per frame
    void Update()
    {
        expText.text = PlayerStats.Instance.Exp + "/50";
    }
}
