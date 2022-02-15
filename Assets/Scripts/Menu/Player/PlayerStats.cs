using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Exp;
    public int startExp = 0;

    private static PlayerStats instance;

    public static PlayerStats Instance
    {
        get{ return instance; }
    }

    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Exp = startExp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Exp >= 50)
        {
            Exp = 0;    
        }
     }
}
