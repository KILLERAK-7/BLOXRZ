using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    bool isMoving = false;
    public bool disabled = false;
    public Rigidbody rb;
    
    void Start()
    {
        speed = 250;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(!disabled)
        {
            movement();
        }
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

        if(Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(Roll(Vector3.right));
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(Roll(Vector3.left));
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(Roll(Vector3.forward));
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(Roll(Vector3.back));
        }
    }

    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;
        if(isMoving)
        {
            float remainingAngle = 90;
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
            Vector3 rotationCenter = transform.position + direction/2 + Vector3.down/2;                

            while(remainingAngle > 0)
            {
                float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
                transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
                remainingAngle -= rotationAngle;
                yield return null;
            }
            isMoving = false;
        }
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
        yield return new WaitForSeconds(1.0f);
    }
}
