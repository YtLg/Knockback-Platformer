using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeController : MonoBehaviour
{
    [HideInInspector] public bool isFrozen;

    public bool getFrozen()
    {
        return isFrozen;
    }

    public void setFrozen(bool frozen)
    {
        isFrozen = frozen;
    }

    void Update()
    {
        //if (isFrozen)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
       // }
       // else
       // {
       //     Cursor.lockState = CursorLockMode.None;
       // }
    }
}
