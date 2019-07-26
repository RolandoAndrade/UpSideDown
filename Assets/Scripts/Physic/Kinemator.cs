using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinemator : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D c = collision.attachedRigidbody;
        c.freezeRotation = true;
        c.Sleep();
        c.isKinematic = true;
    }
}