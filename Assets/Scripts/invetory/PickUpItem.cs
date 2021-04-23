using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpItem : MonoBehaviour
{
    public Item itemData;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Destroy(gameObject);

            GameManager.instance.AddItem(itemData);
        }
    }
}
