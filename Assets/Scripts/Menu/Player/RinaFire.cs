using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinaFire : MonoBehaviour
{
    public bool IsFiring;
    public bool StopFire;
    Enemy enemy;

    // Update is called once per frame
    void Update()
    {
        if (IsFiring == true)
        {
            if (StopFire == false)
            {
                StopFire = true;
                StartCoroutine(DamageByFire());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            IsFiring = true;
            enemy = other.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            IsFiring = false;
        }
    }

    IEnumerator DamageByFire()
    {
        yield return new WaitForSeconds(1.0f);

        enemy.health -= 10;
        StopFire = false;

    }
}
