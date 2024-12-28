using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public RespawnController respController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            respController.currCheckpoint = transform.position + new Vector3(0, 5, 0) ;
        }
    }
}
