using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pote : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Smash(){
        anim.SetBool("smash", true);
        StartCoroutine(breakCO());
    }

    IEnumerator breakCO(){
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
    }
}
