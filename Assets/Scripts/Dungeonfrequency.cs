using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeonfrequency : MonoBehaviour
{
    public Frequencia dungeonfrequency;

    private void Start() {
    if (dungeonfrequency.estado[1])
        {
           Debug.Log("Deu certo bixiga");
           dungeonfrequency.estado[1]= false;
        }
    }


}
