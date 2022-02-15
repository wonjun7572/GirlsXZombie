using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Image imageScreen;

    //public Transform EnemyPrefab;
    //public GameObject EnemyPrefab;
    //public GameObject[] EnemyPrefab = new GameObject[2];
    public List<GameObject> EnemyPrefab;

    public Transform spawnPoint;

    public GameObject GameOverPanel;

    public float timeBetweenWaves = 2f;

    private float countdown = 2f;

    private int waveIndex = 1;

    public int maxEnemyCount = 0;

    public bool getgoldcheck = false;

    //bool IsPause;
    public int goldreward = 0;

    public int EnemyCurrentCountNum;

    private static Spawner instance;

    public static Spawner Instance
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

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        StartCoroutine(_GameOver());

        //GameOver();
        EnemyCheck();
    }
  
    private IEnumerator HitAlphaAnimation()
    {
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            imageScreen.color = color;

            yield return null;
        }
    }

    IEnumerator SpawnWave()
    {
        //waveIndex++;

        for (int i =0; i<waveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    public void EnemyCheck()
    {
        var Enemycount = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyCurrentCountNum = Enemycount.Length;
        //Debug.Log(EnemyCurrentCountNum);
    }

    void SpawnEnemy()
    {
        maxEnemyCount++;

        if (maxEnemyCount <= 50)
        {
            Instantiate(EnemyPrefab[0], spawnPoint.position, spawnPoint.rotation);
        }
        else if (50 < maxEnemyCount && maxEnemyCount <= 100)
        {
            Instantiate(EnemyPrefab[1], spawnPoint.position, spawnPoint.rotation);
        }
        else if (100 < maxEnemyCount && maxEnemyCount <= 150)
        {
            Instantiate(EnemyPrefab[2], spawnPoint.position, spawnPoint.rotation);
        }
        else if (150 < maxEnemyCount && maxEnemyCount <= 200)
        {
            Instantiate(EnemyPrefab[3], spawnPoint.position, spawnPoint.rotation);
        }
        else if (200 < maxEnemyCount && maxEnemyCount <= 250)
        {
            Instantiate(EnemyPrefab[4], spawnPoint.position, spawnPoint.rotation);
        }
        else if (250 < maxEnemyCount && maxEnemyCount <= 300)
        {
            Instantiate(EnemyPrefab[5], spawnPoint.position, spawnPoint.rotation);
        }
        else if (300 < maxEnemyCount && maxEnemyCount <= 350)
        {
            Instantiate(EnemyPrefab[6], spawnPoint.position, spawnPoint.rotation);
        }
        else if (350 < maxEnemyCount && maxEnemyCount <= 400)
        {
            Instantiate(EnemyPrefab[7], spawnPoint.position, spawnPoint.rotation);
        }
        else if (400 < maxEnemyCount && maxEnemyCount <= 450)
        {
            Instantiate(EnemyPrefab[8], spawnPoint.position, spawnPoint.rotation);
        }
        else if (450 < maxEnemyCount && maxEnemyCount <= 500)
        {
            Instantiate(EnemyPrefab[9], spawnPoint.position, spawnPoint.rotation);
        }
        else if (500 < maxEnemyCount && maxEnemyCount <= 560)
        {
            Instantiate(EnemyPrefab[10], spawnPoint.position, spawnPoint.rotation);
        }
        else if (560 < maxEnemyCount && maxEnemyCount <= 620)
        {
            Instantiate(EnemyPrefab[11], spawnPoint.position, spawnPoint.rotation);
        }
        else if (620 < maxEnemyCount && maxEnemyCount <= 680)
        {
            Instantiate(EnemyPrefab[12], spawnPoint.position, spawnPoint.rotation);
        }
        else if (680 < maxEnemyCount && maxEnemyCount <= 740)
        {
            Instantiate(EnemyPrefab[13], spawnPoint.position, spawnPoint.rotation);
        }
        else if (740 < maxEnemyCount && maxEnemyCount <= 800)
        {
            Instantiate(EnemyPrefab[14], spawnPoint.position, spawnPoint.rotation);
        }
        else if (800 < maxEnemyCount && maxEnemyCount <= 860)
        {
            Instantiate(EnemyPrefab[15], spawnPoint.position, spawnPoint.rotation);
        }
        else if (860 < maxEnemyCount && maxEnemyCount <= 920)
        {
            Instantiate(EnemyPrefab[16], spawnPoint.position, spawnPoint.rotation);
        }
        else if (920 < maxEnemyCount && maxEnemyCount <= 980)
        {
            Instantiate(EnemyPrefab[17], spawnPoint.position, spawnPoint.rotation);
        }
        else if (980 < maxEnemyCount && maxEnemyCount <= 1040)
        {
            Instantiate(EnemyPrefab[18], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1040 < maxEnemyCount && maxEnemyCount <= 1100)
        {
            Instantiate(EnemyPrefab[19], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1100 < maxEnemyCount && maxEnemyCount <= 1180)
        {
            Instantiate(EnemyPrefab[20], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1180 < maxEnemyCount && maxEnemyCount <= 1260)
        {
            Instantiate(EnemyPrefab[21], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1260 < maxEnemyCount && maxEnemyCount <= 1340)
        {
            Instantiate(EnemyPrefab[22], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1340 < maxEnemyCount && maxEnemyCount <= 1420)
        {
            Instantiate(EnemyPrefab[23], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1420 < maxEnemyCount && maxEnemyCount <= 1500)
        {
            Instantiate(EnemyPrefab[24], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1500 < maxEnemyCount && maxEnemyCount <= 1580)
        {
            Instantiate(EnemyPrefab[25], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1580 < maxEnemyCount && maxEnemyCount <= 1660)
        {
            Instantiate(EnemyPrefab[26], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1660 < maxEnemyCount && maxEnemyCount <= 1740)
        {
            Instantiate(EnemyPrefab[27], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1740 < maxEnemyCount && maxEnemyCount <= 1820)
        {
            Instantiate(EnemyPrefab[28], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1820 < maxEnemyCount && maxEnemyCount <= 1900)
        {
            Instantiate(EnemyPrefab[29], spawnPoint.position, spawnPoint.rotation);
        }
        else if (1900 < maxEnemyCount && maxEnemyCount <= 2000)
        {
            Instantiate(EnemyPrefab[30], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2000 < maxEnemyCount && maxEnemyCount <= 2100)
        {
            Instantiate(EnemyPrefab[31], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2100 < maxEnemyCount && maxEnemyCount <= 2200)
        {
            Instantiate(EnemyPrefab[32], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2200 < maxEnemyCount && maxEnemyCount <= 2300)
        {
            Instantiate(EnemyPrefab[33], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2300 < maxEnemyCount && maxEnemyCount <= 2400)
        {
            Instantiate(EnemyPrefab[34], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2400 < maxEnemyCount && maxEnemyCount <= 2500)
        {
            Instantiate(EnemyPrefab[35], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2500 < maxEnemyCount && maxEnemyCount <= 2600)
        {
            Instantiate(EnemyPrefab[36], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2600 < maxEnemyCount && maxEnemyCount <= 2700)
        {
            Instantiate(EnemyPrefab[37], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2700 < maxEnemyCount && maxEnemyCount <= 2800)
        {
            Instantiate(EnemyPrefab[38], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2800 < maxEnemyCount && maxEnemyCount <= 2900)
        {
            Instantiate(EnemyPrefab[39], spawnPoint.position, spawnPoint.rotation);
        }
        else if (2900 < maxEnemyCount && maxEnemyCount <= 3020)
        {
            Instantiate(EnemyPrefab[40], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3020 < maxEnemyCount && maxEnemyCount <= 3140)
        {
            Instantiate(EnemyPrefab[41], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3140 < maxEnemyCount && maxEnemyCount <= 3260)
        {
            Instantiate(EnemyPrefab[42], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3260 < maxEnemyCount && maxEnemyCount <= 3380)
        {
            Instantiate(EnemyPrefab[43], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3380 < maxEnemyCount && maxEnemyCount <= 3500)
        {
            Instantiate(EnemyPrefab[44], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3500 < maxEnemyCount && maxEnemyCount <= 3650)
        {
            Instantiate(EnemyPrefab[45], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3650 < maxEnemyCount && maxEnemyCount <= 3800)
        {
            Instantiate(EnemyPrefab[46], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3800 < maxEnemyCount && maxEnemyCount <= 3950)
        {
            Instantiate(EnemyPrefab[47], spawnPoint.position, spawnPoint.rotation);
        }
        else if (3950 < maxEnemyCount && maxEnemyCount <= 4100)
        {
            Instantiate(EnemyPrefab[48], spawnPoint.position, spawnPoint.rotation);
        }
        else if (4100 < maxEnemyCount && maxEnemyCount <= 4250)
        {
            Instantiate(EnemyPrefab[49], spawnPoint.position, spawnPoint.rotation);
        }
        else if (4250 < maxEnemyCount)
        {
            Instantiate(EnemyPrefab[Random.Range(47, 50)], spawnPoint.position, spawnPoint.rotation);
        }

        if (EnemyCurrentCountNum < 49 && EnemyCurrentCountNum >= 40)
        {
            StopCoroutine("HitAlphaAnimation");
            StartCoroutine("HitAlphaAnimation");
        }

        
    }

    public void GetGold()
    {
        if(getgoldcheck == false)
        {
            if (StageMgr.StageCount == 1)
            {
                
                goldreward = 0;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 2)
            {
                
                PlayerPrefsMgr._gold += 50;
                goldreward = 50;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 3)
            {
                PlayerPrefsMgr._gold += 100;
                
                goldreward = 100;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 4)
            {
                PlayerPrefsMgr._gold += 150;
                
                goldreward = 150;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 5)
            {
                PlayerPrefsMgr._gold += 200;
                
                goldreward = 200;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 6)
            {
                PlayerPrefsMgr._gold += 250;
                
                goldreward = 250;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 7)
            {
                PlayerPrefsMgr._gold += 300;
                
                goldreward = 300;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 8)
            {
                PlayerPrefsMgr._gold += 360;
                
                goldreward = 360;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 9)
            {
                PlayerPrefsMgr._gold += 420;
                
                goldreward = 420;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 10)
            {
                PlayerPrefsMgr._gold += 500;
                
                goldreward = 500;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 11)
            {
                PlayerPrefsMgr._gold += 580;
                
                goldreward = 580;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 12)
            {
                PlayerPrefsMgr._gold += 660;
                
                goldreward = 660;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 13)
            {
                PlayerPrefsMgr._gold += 740;
                
                goldreward = 740;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 14)
            {
                PlayerPrefsMgr._gold += 840;
                
                goldreward = 840;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 15)
            {
                PlayerPrefsMgr._gold += 940;
                
                goldreward = 940;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 16)
            {
                PlayerPrefsMgr._gold += 1040;
                
                goldreward = 1040;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 17)
            {
                PlayerPrefsMgr._gold += 1160;
                
                goldreward = 1160;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 18)
            {
                PlayerPrefsMgr._gold += 1280;
                
                goldreward = 1280;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 19)
            {
                PlayerPrefsMgr._gold += 1430;
                
                goldreward = 1430;
                getgoldcheck = true;
            }
            else if (StageMgr.StageCount == 20)
            {
                PlayerPrefsMgr._gold += 1580;
                
                goldreward = 1580;
                getgoldcheck = true;
            }
        }       
    }

    //void GameOver()
    //{
    //    if (EnemyCurrentCountNum >= 50)
    //    {
    //       Time.timeScale = 0f;
    //       GameObject.Find("GameOverPanel").GetComponent<UIScreenDisplay>().Show();
    //       FindCharacterValue.Instance.SetCharacterValue();
    //        GetGold();
    //    }
    //}

    IEnumerator _GameOver()
    {
        if (EnemyCurrentCountNum >= 50)
        {
            Time.timeScale = 0f;
            GameObject.Find("GameOverPanel").GetComponent<UIScreenDisplay>().Show();
            FindCharacterValue.Instance.SetCharacterValue();
            GetGold();
        }
        yield return new WaitForSeconds(1.0f);
    }
}
