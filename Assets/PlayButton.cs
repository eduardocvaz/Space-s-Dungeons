using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Vector2 playerPosition;
    public string sceneToLoad;
    public VectorValue playerStorage;

    public void PlayGame()
    {
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene("Load");
    }
    public void Quit()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
