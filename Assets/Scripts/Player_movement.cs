using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int speed;
    bool isMoving = false;
    public bool disabled = false;
    public Rigidbody rb;
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(!disabled)
        {
            movement();
        }

        void Assemble(Vector3 dir)
        {
            var rotationAxis = Vector3.Cross(Vector3.up, dir);
            var rotationCenter = transform.position + (Vector3.down + dir) * 0.5f; 
            StartCoroutine(Roll(rotationCenter , rotationAxis));
        }

        void movement()
        {
            if(isMoving)
            {
                return;
            }

            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame();
            } 

            if(Input.GetKey(KeyCode.A))
            {
                Assemble(Vector3.left);
            }
            if(Input.GetKey(KeyCode.D))
            {
                Assemble(Vector3.right);
            }
            if(Input.GetKey(KeyCode.W))
            {
                Assemble(Vector3.forward);
            }
            if(Input.GetKey(KeyCode.S))
            {
                Assemble(Vector3.back);
            }
        }

    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;                       

        for(int i = 0; i < (90/ speed);i++)
        {
            transform.RotateAround(anchor, axis, speed);
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }

    void OnCollisionExit (Collision other)
    {
        if(other.gameObject.tag.Equals("Destruction"))
        {
            StartCoroutine(delay());
            Destroy(other.gameObject);
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
    }
}