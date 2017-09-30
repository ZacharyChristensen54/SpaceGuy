using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {


    public Vector2 speed = new Vector2(10, 10);

    private Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D[] rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody2D>();
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

        float xPos = transform.position.x;
        if (xPos > 1)
            direction = new Vector2(-1, 0);
        if (xPos < -1)
            direction = new Vector2(1, 0);

        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    void FixedUpdate()
    {
        if (rb == null)
            rb = GetComponentsInChildren<Rigidbody2D>();

        float xPos = transform.position.x;
        if (xPos > 2 || xPos < -2)
        {
            
            for (int i = 0; i < rb.Length; i++)
            {
                if (rb[i] != null)
                    rb[i].velocity = movement;
            }
        }
    }
}

