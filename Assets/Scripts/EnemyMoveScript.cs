using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {


    public Vector2 speed = new Vector2(10, 10);
    public float leftBound = -2;
    public float rightBound = 2;

    private Vector2 direction = new Vector2(-1, -1);
    
    private float xPos;
    private Vector2 movement;

    private void Update()
    {
        xPos = transform.position.x;

        if (xPos > rightBound)
            direction.x = -1;
        if (xPos < leftBound)
            direction.x = 1;

        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        transform.Translate(movement * Time.deltaTime);
    }


}

