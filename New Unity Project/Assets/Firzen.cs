using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firzen : MonoBehaviour
{
    public float Speed = 3.5f;
   public GameObject FirzenObj;
    public GameObject FreezeObj;
    public GameObject FirzenBall;
    public GameObject FreezeBall;
    public Animator freeze;
    public Animator firzen;
    public Animator firzenball;
    public Animator freezeball;
    Rigidbody2D rigid;
    Vector3 movement, movement2;
    bool once1 = false;
    bool once2= false;
    bool iscasted1 = false;
    bool iscasted2 = false;
    void Start(){
        FirzenBall.SetActive(false);
        FreezeBall.SetActive(false);
        firzen.GetComponent<Animator>();
        freeze.GetComponent<Animator>();
        firzenball.GetComponent<Animator>();
        freezeball.GetComponent<Animator>();

    }
    
    // Update is called once per frame
    void Update()
    {
        
       if( freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_run") && FreezeObj.transform.position.x < 0.5){
            freeze.SetBool("isRunning", false);
            freeze.SetTrigger("attack");
            
        }
        if(freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_run_attack")){
          freeze.SetTrigger("fallback");
           
        }

         if(freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_fall_back")){
             movement = new Vector3(1, 0, 0f);
            movement = movement * 5f * Time.deltaTime;
            FreezeObj.transform.position += movement;
        freeze.SetTrigger("getup");
        }

        if(freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_get_up")){
           freeze.SetBool("isIdle", true);
        }
 
        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_idle") && once1 == false)
        {
            freeze.SetBool("isIdle", false);
            freeze.SetBool("isRunning", true);
            once1 = true;
        }
        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_idle") && once1 == true && iscasted1 == false)
        {
            freeze.SetTrigger("Cast");
            freeze.SetBool("isIdle", false);
            iscasted1 = true;
        }

        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_run") && FreezeObj.transform.position.x > 0.5 )
        {

            movement = new Vector3(1, 0, 0f);
            movement = movement * Speed * Time.deltaTime;
            FreezeObj.transform.position -= movement;
        }
        if (freeze.GetCurrentAnimatorStateInfo(0).IsName("freeze_throw_ball"))
        {
            freeze.SetBool("Cast", false);
            freeze.SetBool("isIdle", true);

        }
        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_idle") && once2 == true && iscasted2 == true)
        {
           // FreezeBall.SetActive(true);
        }



        if ( firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_run") && FirzenObj.transform.position.x > -0.5){
            firzen.SetBool("isRunning", false);
            firzen.SetTrigger("attack");

            
        }
        if(firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_fall_back")){
             movement2 = new Vector3(1, 0, 0f);
            movement2 = movement2 * 8f * Time.deltaTime;
            FirzenObj.transform.position -= movement2;
                firzen.SetTrigger("getup");
        }
        if(firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_run_attack")){
                firzen.SetTrigger("fallback");
        }
        
        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_idle") && once2 == false)
        {
            firzen.SetBool("isIdle", false);
            firzen.SetBool("isRunning", true);
             once2 = true;
        }
        if(firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_get_up")){
           firzen.SetBool("isIdle", true);
        }
        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_run") && FirzenObj.transform.position.x  < -0.5)
        {
                movement = new Vector3(1, 0, 0f);
                movement = movement * Speed * Time.deltaTime;
                FirzenObj.transform.position += movement;
        }

        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_idle") && once2 == true && iscasted2 == false)
        {
            firzen.SetBool("Cast",true);
            firzen.SetBool("isIdle", false);
            FirzenBall.SetActive(false);
            iscasted2 = true;
        }
        if (firzen.GetCurrentAnimatorStateInfo(0).IsName("firzen_throw_ball") )
        {
            firzen.SetBool("Cast", false);
            firzen.SetBool("isIdle", true);
            
        }
      if(iscasted2)
            FirzenBall.SetActive(true);
    }
    private void FixedUpdate() {
        
    }
}
