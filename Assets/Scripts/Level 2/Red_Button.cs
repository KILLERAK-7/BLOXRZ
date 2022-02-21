using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player2;
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
            bridge.transform.position = new Vector3(1,0,-1);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player2)
        {
            count = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player2) 
        {
            count = false;
        }
    }
}
