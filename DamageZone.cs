using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //void OnTriggerEnter2D(Collider2D collision)
    void OnTriggerStay2D(Collider2D collision)//This function is called every frame the Rigidbody is inside the Trigger instead of just once when it enters.
    {
        PlayerController allahwahebi = collision.GetComponent<PlayerController>();

        if (allahwahebi != null)
        {
            allahwahebi.ChangeHealth(-1);         
        }
    }
}
