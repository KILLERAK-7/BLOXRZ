using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Trigger : MonoBehaviour
{
    public GameObject player1;
    public bool End1;

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject == player1)
        {
            End1 = true;
        }
    }   

    void OncollisionExit (Collision other)
    {
        if(other.gameObject == player1)
        {
            End1 = false;
        }
    }
    
}
