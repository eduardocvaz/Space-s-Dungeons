using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour {

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public LootTable thisLoot;
    public Frequencia dungeonfrequency;
    public int indentificador;

    private void Awake() {
        health = maxHealth.initialValue;
        if (dungeonfrequency.estado[indentificador]==false)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void TakeDamage(float damage){
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            MakeLoot();
            dungeonfrequency.estado[indentificador]=false;
        }
    }
    private void MakeLoot(){
        if (thisLoot != null)
        {
            PickUpItem current = thisLoot.LootItem();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime,float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }


    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}