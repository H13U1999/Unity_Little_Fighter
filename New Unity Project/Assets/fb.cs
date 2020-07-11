using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fb : MonoBehaviour
{
    public Animator firzenball;
    public Animator freezeball;
    public GameObject FirzenBall;
    public GameObject FreezeBall;
    void Start()
    {
        firzenball.GetComponent<Animator>();
        freezeball.GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FirzenBall.transform.position = other.transform.position;
        freezeball.SetTrigger("disolve");
        firzenball.SetTrigger("disolve");
    
    }
  /*  void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name=="FirzenBall")
        freezeball.SetTrigger("disolve");
        firzenball.SetTrigger("disolve");
    }
    */
}
