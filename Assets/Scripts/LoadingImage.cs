using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingImage : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        Sprite select = sprites[index];
        image.sprite = select;
    }
}
