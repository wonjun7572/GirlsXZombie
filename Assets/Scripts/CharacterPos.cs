using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPos : MonoBehaviour
{
    public Transform character;

    // Update is called once per frame
    void Update()
    {
        transform.position = character.position;
    }
}
