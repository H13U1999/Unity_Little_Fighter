using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpSpeed = 500f;
    public Rigidbody2D rgb;
    public float objectY;
    Vector2 movement;
    void Start(){
        objectY = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;
        bool isDefending = false;
        bool isRunning = false;
        if(Input.GetKey(KeyCode.J)){
            GetComponent<Animator>().SetTrigger("Def");
            isDefending = true;
        }
        if(isDefending == false){
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
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,JumpSpeed));
        }
         if (Input.GetKeyDown(KeyCode.D) )
        {
            if(Input.GetKey(KeyCode.D)){
            horizontal = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Run",true);
            isRunning =true;}
            else{
                horizontal = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetTrigger("Walk");
            }
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Run",true);
            isRunning =true;
        }

        }
         if(isRunning)
         transform.position = rgb.position + movement * 10f * Time.fixedDeltaTime;

        movement.x = horizontal;
        movement.y = vertical;
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y,-10f,-1));
    }
    void FixedUpdate()
    {
        rgb.MovePosition(rgb.position + movement * MoveSpeed * Time.fixedDeltaTime);
       
    }
}
