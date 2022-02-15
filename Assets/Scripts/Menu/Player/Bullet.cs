using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float slowvalue = 0f; // 제이미 슬로우 speed 값
    public float stunvalue = 0f; // 아망딩 스턴 speed 값

    public float explosionRadius = 0f;
    public int damage = 50;

    public GameObject impactEffect;

    public AudioClip clip;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        SoundMgr.instance.SFXPlay("Bullet", clip);
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (explosionRadius > 0f)
        {
            Explode();
        }

        else if (slowvalue == 1f)
        {
            Slow(target);
        }

        else if (stunvalue == 1f)
        {
            Stun(target);
        }

        else
        {
            Damage(target);
        }

        //Damage(target);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Slow(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.speed = 0.5f;
        Damage(target);
    }

    void Stun(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.speed = 0f;
        Damage(target);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}