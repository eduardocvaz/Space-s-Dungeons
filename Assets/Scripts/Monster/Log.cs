using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anime;

    // Start is called before the first fram    e update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
        && Vector3.Distance(transform.position,target.position) > attackRadius)
        {
            anime.SetBool("wakeUp", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        }
        else
        {
            anime.SetBool("wakeUp", false);
        }
    }
}
