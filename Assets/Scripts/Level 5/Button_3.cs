using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    private bool count;
    public GameObject bridge1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count)
        {
            bridge1.transform.position = new Vector3(-3,0,4);
        }
        else{
            bridge1.transform.position = new Vector3(-3,-3,4);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player1 || other.gameObject == player2)
        {
            count = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1 || other.gameObject == player2) 
        {
            count = false;
        }
    }
}