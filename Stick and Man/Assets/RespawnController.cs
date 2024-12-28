using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{

    private static RespawnController instance;

    public Vector2 currCheckpoint;
    public Transform startPoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
