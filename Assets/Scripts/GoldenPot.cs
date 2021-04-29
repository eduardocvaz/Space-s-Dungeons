using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPot : MonoBehaviour
{
    public LootTable thisLoot;
    public Frequencia dungeonfrequency;
    public int indentificador;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        if (dungeonfrequency.estado[indentificador]==false)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Smash(){
        anim.SetBool("smash", true);
        StartCoroutine(breakCO());
    }
    private void MakePotLoot(){
        if (thisLoot != null)
        {
            PickUpItem current = thisLoot.LootItem();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator breakCO(){
        MakePotLoot();
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
        dungeonfrequency.estado[indentificador]=false;

    }
}
