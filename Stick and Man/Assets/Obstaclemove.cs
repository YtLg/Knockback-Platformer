using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclemove : MonoBehaviour
{
    public GameObject goal;
    private Transform currentPoint;
    private Rigidbody2D rb;
    public float speed;
    public FreezeController freeze;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = goal.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze.isFrozen)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            Vector2 point = currentPoint.position - transform.position;
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == goal.transform)
            {
                rb.velocity = new Vector2(0, 0);
            }

            if (currentPoint == goal.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
