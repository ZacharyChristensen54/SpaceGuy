using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {


    public Vector2 speed = new Vector2(10, 10);
    public float leftBound = -2;
    public float rightBound = 2;
    public float yDecrement = .2f;

    private Vector2 direction = new Vector2(-1, 0);

    private float yPos;
    private float xPos;
    private Vector2 movement;

    private Rigidbody2D[] rb;
    

    // Use this for initialization
    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody2D>();
        yPos = transform.position.y;
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].velocity = new Vector2(speed.x, 0);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (rb == null)
            rb = GetComponentsInChildren<Rigidbody2D>();

        xPos = transform.position.x;
        if (xPos > rightBound)
            direction = new Vector2(-1, 0);
        if (xPos < leftBound)
            direction = new Vector2(1, 0);

        if (xPos > rightBound || xPos < leftBound)
        {
            if (transform.position.y == yPos)
            {
                movement = new Vector2(0, speed.y * -1f);
                for (int i = 0; i < rb.Length; i++)
                {
                    if (rb[i] != null)
                        rb[i].velocity = movement;
                }
            }
        }

        if (transform.position.y < (yPos - yDecrement))
        {
            yPos = transform.position.y;

            movement = new Vector2(direction.x * speed.x, 0);
            for (int i = 0; i < rb.Length; i++)
            {
                if (rb[i] != null)
                    rb[i].velocity = movement;
            }
        }
    }
}

