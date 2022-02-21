using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Trigger_2 : MonoBehaviour
{
    public GameObject player2;
    public bool End2;

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject == player2)
        {
            End2 = true;
        }
    }

    void OnCollisionExit (Collision other)
    {
        if(other.gameObject == player2)
        {
                End2 = false;
        }
    }
}

