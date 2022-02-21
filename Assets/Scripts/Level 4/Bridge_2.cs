using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    private bool count;
    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject bridge3;
    public GameObject button1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count)
        {
            bridge1.transform.position = new Vector3(-4,0,-3);
            bridge2.transform.position = new Vector3(-3,0,-3);
            bridge3.transform.position = new Vector3(-3,0,-4);
            button1.transform.position = new Vector3(-3,0.05f,-3);
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
