using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movelevel : MonoBehaviour
{
    public int sceneIndex;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print("switching to scene " + sceneIndex);
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
