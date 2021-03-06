﻿using UnityEngine;
using System.Collections;

public class Paddle2 : MonoBehaviour
{
	public bool autoPlay = false;
	public float minX, maxX;

	private Ball ball;
	
	void Start ()
    {
		ball = GameObject.FindObjectOfType<Ball>();
	}
		
	// Update is called once per frame
	void Update ()
    {
        MoveWithArrowKeys();
	}

    void MoveWithArrowKeys()
    {
        if(this.transform.position.y >= minX && this.transform.position.y <= maxX)
        {
            Vector3 direction = MoveDirectionBoth();
            this.transform.Translate(direction * 10 * Time.deltaTime);
        }
        else if(this.transform.position.y < maxX)
        {
            Vector3 direction = MoveDirectionUp();
            this.transform.Translate(direction * 10 * Time.deltaTime);
        }
        else if(this.transform.position.y > minX)
        {
            Vector3 direction = MoveDirectionDown();
            this.transform.Translate(direction * 10 * Time.deltaTime);
        }
    }

    private Vector3 MoveDirectionBoth()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.x += 1.0f;
        }
        return direction.normalized;
    }

    private Vector3 MoveDirectionUp()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction.x -= 1.0f;
        }
        return direction.normalized;
    }

    private Vector3 MoveDirectionDown()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
        {
            direction.x += 1.0f;
        }
        return direction.normalized;
    }
}
