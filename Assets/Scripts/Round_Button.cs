using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    private bool count;
    public GameObject bridge1;
    public GameObject bridge2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count)
        {
            bridge1.transform.position = new Vector3(1,0,-2);
            bridge2.transform.position = new Vector3(1,0,-3);
        }
        else{
            bridge1.transform.position = new Vector3(1,-2,-2);
            bridge2.transform.position = new Vector3(1,-2,-3);
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
