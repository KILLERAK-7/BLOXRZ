using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    Player_movement P1;

    public GameObject player;
    
    void Start()
    {
        P1 = FindObjectOfType<Player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            StartCoroutine("Tp");
        }
    }

    IEnumerator Tp()
    {
        
        P1.disabled = true;
        yield return new WaitForSeconds(0.5f);
        player.transform.position = new Vector3(-1f,0.5f,-1f);
        yield return new WaitForSeconds(0.5f);
        P1.disabled = false;
    }
}
