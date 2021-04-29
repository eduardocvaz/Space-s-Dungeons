using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDungeon : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public Frequencia dungeonfrequency0;
    public Frequencia dungeonfrequency1;
    public int quantidadeReset;
    public Frequencia BossBool;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            ResetDun();
        }
    }
    public void ResetDun(){
        BossBool.estado[0]=false;
        for (int i = 0; i < quantidadeReset; i++)
        {
            dungeonfrequency0.estado[i]=true;
            dungeonfrequency1.estado[i]=true;
        }
    }
}
