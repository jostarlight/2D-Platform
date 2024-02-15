using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour
{
    public Transform reborn;
    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = reborn.position;
    }
}
