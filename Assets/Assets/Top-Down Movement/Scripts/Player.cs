﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        walk,
        attack
    }
    public Animator anim;
    public float speed;
    public VectorValue startingPosition;
    public PlayerState currentState;
    private Rigidbody2D myRigidbody;    
    private  Vector3 movement;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
        anim.SetFloat("Horizontal", 0);
        anim.SetFloat("Vertical", -1);
    }
    // Update is called once per frame
    void Update()
    {
            movement = Vector3.zero;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }
    private IEnumerator AttackCo(){
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    private void UpdateAnimationAndMove(){
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        if (movement != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("Horizontal",movement.x);
            anim.SetFloat("Vertical",movement.y);
            //anim.SetFloat("Speed",movement.magnitude);

            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
    void MoveCharacter(){
        movement.Normalize();
        myRigidbody.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}
