using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject virCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("player is in this area");
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            virCam.SetActive(true);
            Debug.Log("camera activated");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virCam.SetActive(false);
        }
    }

}
