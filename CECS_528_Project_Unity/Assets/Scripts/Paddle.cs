using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

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
        if(this.transform.position.x >= minX && this.transform.position.x <= maxX)
        {
            Vector3 direction = MoveDirectionBoth();
            this.transform.Translate(direction * 10 * Time.deltaTime);
        }
        else if(this.transform.position.x > maxX)
        {
            Vector3 direction = MoveDirectionLeft();
            this.transform.Translate(direction * 10 * Time.deltaTime);
        }
        else if(this.transform.position.x < minX)
        {
            Vector3 direction = MoveDirectionRight();
            this.transform.Translate(direction * 10 * Time.deltaTime);
        }
    }

    private Vector3 MoveDirectionBoth()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
        }
        return direction.normalized;
    }

    private Vector3 MoveDirectionLeft()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x -= 1.0f;
        }
        return direction.normalized;
    }

    private Vector3 MoveDirectionRight()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
        }
        return direction.normalized;
    }
}
