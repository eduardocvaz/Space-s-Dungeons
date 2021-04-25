using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anime;

    // Start is called before the first fram    e update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anime= GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
        && Vector3.Distance(transform.position,target.position) > attackRadius)
        {

            if (currentState == EnemyState.idle || currentState == EnemyState.walk 
            && currentState != EnemyState.stagger)
            {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            changeAnim(temp - transform.position);
            myRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);
            anime.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius )
        {
            anime.SetBool("wakeUp", false);
        }
    }
    private void SetAnimFloat(Vector2 setVector){
        anime.SetFloat("Horizontal", setVector.x);
        anime.SetFloat("Vertical", setVector.y);
    }
    private void changeAnim(Vector2 direction){
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0){
                SetAnimFloat(Vector2.up);
            }else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    private void ChangeState(EnemyState newState){
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
