using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    public float Xrotspeed = 400.0f;
    public float YrotSpeed = 300.0f;
    private float x,y;

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime * Xrotspeed;
        y += Time.deltaTime * YrotSpeed;
        transform.rotation = Quaternion.Euler(x, y, 0);
    }
}
