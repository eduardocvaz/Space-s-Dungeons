using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject inventoryMenu;    
    private Scene scene;

    private void Start() {
        inventoryMenu.gameObject.SetActive(false);

        scene = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene.name);
    }
    private void Update() {
        InventoryControl();
    }
    private void InventoryControl(){
        if (Input.GetKeyDown(KeyCode.Escape) && scene.name!="Menu")
        {
            if (GameManager.instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void Resume(){
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }
    private void Pause(){
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
    }
}
