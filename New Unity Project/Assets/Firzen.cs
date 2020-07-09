using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firzen : MonoBehaviour
{
    public float Speed = 5f;
   public GameObject FirzenObj;
    public GameObject FreezeObj;
    public Animator freeze;
    public Animator firzen;
    Rigidbody2D rigid;
    Vector3 movement;
    void Start(){
        firzen.GetComponent<Animator>();
        freeze.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
       if( freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_run") && FreezeObj.transform.position.x < 0){
            freeze.SetBool("isRunning", false);
            freeze.SetTrigger("attack");
            freeze.SetTrigger("fallback");
        }


        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_idle"))
        {
            freeze.SetBool("isRunning", true);
        }

        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_run") && FreezeObj.transform.position.x < 0)
        {
            freeze.SetBool("isRunning", false);
            freeze.SetTrigger("attack");
            freeze.SetTrigger("fallback");
        }


        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_idle"))
        {
            freeze.SetBool("isRunning", true);
        }


        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_run") && FreezeObj.transform.position.x > 0 )
        {

            movement = new Vector3(1, 0, 0f);
            movement = movement * Speed * Time.deltaTime;
            FreezeObj.transform.position -= movement;
        }
        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_idle") )
        {
            firzen.SetBool("isRunning", true);
        }

        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_run") && FirzenObj.transform.position.x  < 0)
        {
           
                movement = new Vector3(1, 0, 0f);
                movement = movement * Speed * Time.deltaTime;
                FirzenObj.transform.position += movement;
        }

        

    }
    private void FixedUpdate() {
        
    }
}
