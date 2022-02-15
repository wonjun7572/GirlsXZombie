using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public GameObject a;
    public Button b;

    private void BtnColorChange()
    {
        b = a.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.selectedColor = new Color(255/255f, 180/255f, 60/255f);
        cb.normalColor = new Color(255 / 255f, 180 / 255f, 60 / 255f);
        b.colors = cb;

    }

    private void BtnColorChangeOff()
    {
        b = a.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.selectedColor = new Color(161/255f, 161/255f, 161/255f);
        cb.normalColor = new Color(161 / 255f, 161 / 255f, 161 / 255f);
        b.colors = cb;

    }
    public void On2xBtnClick()
    {
        if(Time.timeScale < 1.5f)
        {
            Time.timeScale = 2.0f;
            BtnColorChange();
        }

        else 
        {
            Time.timeScale = 1.0f;
            BtnColorChangeOff();
        }
     }
}
