using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorFollow : MonoBehaviour
{
    public Rigidbody2D cursorBody;
    public Sprite clickSprite;
    public Sprite idleSprite;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorBody.MovePosition(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = clickSprite;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
    }

}
