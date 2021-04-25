using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    idle,
    stagger
}
public class Player : MonoBehaviour
{

    public Animator anim;
    public float speed;
    public VectorValue startingPosition;
    public PlayerState currentState;
    private Rigidbody2D myRigidbody;    
    private  Vector3 movement;

    void Start() {
        currentState = PlayerState.walk;
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

        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack 
        && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
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
    public void Knock(float knockTime){
        StartCoroutine(KnockCo(knockTime));
    }
    private IEnumerator KnockCo(float knockTime){
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;    
        }
    }
}
