using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 0f; // enemy의 속도

    public int health; // enemy의 체력
    public int exp; // enemy사망시 얻는 exp

    float Stuntimer = 0;
    float Slowtimer = 0;
    public float StundelayTime = 3f;
    public float SlowdelayTime = 3f;

    // Enemy에게만 사용하기 위해 private 선언
    private Transform target;

    // 웨이 포인트의 인덱스 (기본값은 0)
    private int waypointIndex = 0;

    public float MyAttackTime { get; set; }

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        if (speed == 0f)
        {
            Stuntimer += Time.deltaTime;
        }

        if (speed == 0.5f)
        {
            Slowtimer += Time.deltaTime;
        }

        Vector3 dir = target.position - transform.position;

        // 동일한 고정 속도와 길이를 갖게 하기 위해 정규화 시켜줌
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target.position);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        StunCheck();
        SlowCheck();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Instance.Exp += exp;
        Destroy(gameObject);
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            waypointIndex = -1;
            //Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }

    void StunCheck()
    {
        if (speed == 0f && Stuntimer >= StundelayTime)
        {
            speed = 1f;
            Stuntimer = 0f;
        }
    }

    void SlowCheck()
    {
        if (speed == 0.5f && Slowtimer >= SlowdelayTime)
        {
            speed = 1f;
            Slowtimer = 0f;
        }
    }
}
