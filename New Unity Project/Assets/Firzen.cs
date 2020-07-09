using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firzen : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rigid;
    void Start(){
        rigid = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))  {
            rigid.AddForce(new Vector2(speed,5));
        }
    }
    private void FixedUpdate() {
        rigid.MovePosition(rigid.position);
    }
}
