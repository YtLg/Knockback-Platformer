using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D cursorTextureDown;
    private Vector2 cursorPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
