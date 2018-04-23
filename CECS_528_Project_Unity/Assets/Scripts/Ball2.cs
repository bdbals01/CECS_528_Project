using UnityEngine;
using System.Collections;

public class Ball2 : MonoBehaviour
{

    private Paddle2 paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle2>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch.
            if (Input.GetKeyDown("space"))
            {
                print("Spacebar pressed, launch ball");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(7f, 0f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ball does not trigger sound when brick is destoyed.
        // Not 100% sure why, possibly because brick isn't there.
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
