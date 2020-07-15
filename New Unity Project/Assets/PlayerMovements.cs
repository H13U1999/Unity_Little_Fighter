using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpSpeed = 500f;
    public Rigidbody2D rgb;
    Vector2 movement;
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
            GetComponent<Animator>().SetTrigger("Walk");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,JumpSpeed));
        }

        movement.x = horizontal;
        movement.y = vertical;
    }
    void FixedUpdate()
    {
        rgb.MovePosition(rgb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
