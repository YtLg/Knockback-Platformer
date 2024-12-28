using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePosOffset;
    Vector2 prevObjPosition;
    Vector2 currObjPosition;
    Vector2 flingVelocity;
    Rigidbody2D objectBody;

    public float flingStrength;
    public bool player;
    public float timeout;
    private bool dragging;
    private bool isDragging;

    private Coroutine autoReleaseCoroutine;

    private void Start()
    {
        objectBody = gameObject.GetComponent<Rigidbody2D>();
        if (player == false)
        {
            objectBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }


    private void Update()
    {
        Vector3 cursorScreenPosition = Input.mousePosition;
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorScreenPosition);
        cursorWorldPosition.z = 0;

        Vector3 objectPosition = transform.position;

        float detectionRadius = 0.3f;
        bool isCursorOverObject = Vector2.Distance(new Vector2(cursorWorldPosition.x, cursorWorldPosition.y), new Vector2(objectPosition.x, objectPosition.y)) < detectionRadius;

        if (isCursorOverObject && Input.GetMouseButtonDown(0))
        {
            Debug.Log("COLLIDDEEEED");
            OnMouseDown();
            isDragging = true;
        }

        if (isDragging)
        {
            OnMouseDrag(); 
            if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp();
                Debug.Log("Released");
                isDragging = false;
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        dragging = true;
        mousePosOffset = gameObject.transform.position - GetMouseWorldPosition();

        
        if (player == false)
        {
            objectBody.constraints = RigidbodyConstraints2D.None;
        }

        if (player == true)
        {
            autoReleaseCoroutine = StartCoroutine(AutoReleaseAfterTime());
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
        objectBody.velocity = flingVelocity * flingStrength;
        if (player == false)
        {
            objectBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (autoReleaseCoroutine != null)
        {
            StopCoroutine(autoReleaseCoroutine);
        }
    }

    private void OnMouseDrag()
    {
        if (dragging == true)
        {
            Debug.Log("Dragging");
            Vector3 targetPosition = GetMouseWorldPosition() + mousePosOffset;
            Vector2 targetPosition2D = new(targetPosition.x, targetPosition.y);

            objectBody.MovePosition(targetPosition2D);

            if (player == true)
            {
                currObjPosition = targetPosition2D;
                flingVelocity = (currObjPosition - prevObjPosition) / Time.deltaTime;
                prevObjPosition = currObjPosition;
            }
        }
    }


    private IEnumerator AutoReleaseAfterTime()
    {
        yield return new WaitForSeconds(timeout);

        // Automatically release the object after the specified time
        OnMouseUp();
    }

}

