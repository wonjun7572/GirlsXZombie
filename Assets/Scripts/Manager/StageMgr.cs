using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMgr : MonoBehaviour
{
    public Text stageText;

    public int stageLv = 1;

    public static int StageCount;

    private static StageMgr instance;

    public static StageMgr Instance
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

    // Update is called once per frame
    void Update()
    {
        StageUp();

        stageText.text = "STAGE " + stageLv;
    }

    void StageUp()
    {
        Spawner spawner = GameObject.Find("GameManagement").GetComponent<Spawner>();
        
        if (spawner.maxEnemyCount == 51)
        {
            stageLv = 2;
            StageCount = 2;
        }
        else if (spawner.maxEnemyCount == 100)
        {
            stageLv = 3;
            StageCount = 3;
        }
        else if (spawner.maxEnemyCount == 150)
        {
            stageLv = 4;
            StageCount = 4;
        }
        else if (spawner.maxEnemyCount == 300)
        {
            stageLv = 5;
            StageCount = 5;
        }
        else if (spawner.maxEnemyCount == 450)
        {
            stageLv = 6;
            StageCount = 6;
        }
        else if (spawner.maxEnemyCount == 620)
        {
            stageLv = 7;
            StageCount = 7;
        }
        else if (spawner.maxEnemyCount == 800)
        {
            stageLv = 8;
            StageCount = 8;
        }
        else if (spawner.maxEnemyCount == 980)
        {
            stageLv = 9;
            StageCount = 9;
        }
        else if (spawner.maxEnemyCount == 1180)
        {
            stageLv = 10;
            StageCount = 10;
        }
        else if (spawner.maxEnemyCount == 1420)
        {
            stageLv = 11;
            StageCount = 11;
        }
        else if (spawner.maxEnemyCount == 1660)
        {
            stageLv = 12;
            StageCount = 12;
        }
        else if (spawner.maxEnemyCount == 1900)
        {
            stageLv = 13;
            StageCount = 13;
        }
        else if (spawner.maxEnemyCount == 2200)
        {
            stageLv = 14;
            StageCount = 14;
        }
        else if (spawner.maxEnemyCount == 2500)
        {
            stageLv = 15;
            StageCount = 15;
        }
        else if (spawner.maxEnemyCount == 2800)
        {
            stageLv = 16;
            StageCount = 16;
        }
        else if (spawner.maxEnemyCount == 3140)
        {
            stageLv = 17;
            StageCount = 17;
        }
        else if (spawner.maxEnemyCount == 3500)
        {
            stageLv = 18;
            StageCount = 18;
        }
        else if (spawner.maxEnemyCount == 3950)
        {
            stageLv = 19;
            StageCount = 19;
        }
        else if (spawner.maxEnemyCount == 4100)
        {
            stageLv = 20;
            StageCount = 20;
        }
    }
}
