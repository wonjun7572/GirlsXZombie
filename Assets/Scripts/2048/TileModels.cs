using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileModels : MonoBehaviour 
{
    public List<GameObject> tileModels;

    public GameObject GetModel(int amount)
    {
        //Debug.Log("<color=f00> " + amount + "_" + (int)(Mathf.Log(amount, 2))+ "</color>");
        return tileModels[((int)(Mathf.Log(amount, 2))-1)% tileModels.Count];
    }
}
