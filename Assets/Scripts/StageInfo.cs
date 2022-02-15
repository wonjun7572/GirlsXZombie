using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
    int StageNumber;
    int StageTime;
    string SpawnEnemy;
    int SpawnTime;
    int EnemyCount;
    float EnemySpeed;
    int EnemyHealth;
    int EndCount;
    int KillGold;
    int LobbyGold;

    // Start is called before the first frame update
    void Start()
    {
        Enemy enemy_health = GameObject.Find("Enemy").GetComponent<Enemy>();
        EnemyHealth = enemy_health.health;

        Enemy enemy_speed = GameObject.Find("Enemy").GetComponent<Enemy>();
        EnemySpeed = enemy_speed.speed;

        EnemyHealth = 100;
        EnemySpeed = 0.5f;
 
    }
}
