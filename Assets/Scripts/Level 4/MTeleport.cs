using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    Player_movement P1;
    Player_movement P2;

    public GameObject player1;
    public GameObject player2;
    
    void Start()
    {
        P1 = FindObjectOfType<Player_movement>();
        P2 = FindObjectOfType<Player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player1)
        {
            StartCoroutine("Tp");
        }

        if(other.gameObject == player2)
        {
            StartCoroutine("Tp2");
        }
    }

    IEnumerator Tp()
    {
        
        P1.disabled = true;
        yield return new WaitForSeconds(0.5f);
        player1.transform.position = new Vector3(0-3f,0.5f,-4f);
        yield return new WaitForSeconds(0.5f);
        P1.disabled = false;
    }

    IEnumerator Tp2()
    {
        
        P2.disabled = true;
        yield return new WaitForSeconds(0.5f);
        player2.transform.position = new Vector3(3f,0.5f,4f);
        yield return new WaitForSeconds(0.5f);
        P2.disabled = false;
    }
}
