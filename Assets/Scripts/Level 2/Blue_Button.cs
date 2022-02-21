using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    private bool count;
    public GameObject bridge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count)
        {
            bridge.transform.position = new Vector3(0,0,2);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player1)
        {
            count = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1) 
        {
            count = false;
        }
    }
}
