using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D trigger) {
        print(trigger.gameObject.name.ToString());
        if (trigger.gameObject.name.StartsWith("Ball"))
        {
            //Debug.Log("Destroying the ball");
            Destroy(trigger.gameObject);
            print("Destroyed the ball");
        }
        if ((GameObject.FindObjectsOfType<Ball>().Length <= 0) && (GameObject.FindObjectsOfType<Ball2>().Length == 0 || GameObject.FindObjectsOfType<Ball3>().Length == 0))
        {
            //print("Quitting");
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Gameover Screen");
        }
        //print("Quitting");
        //levelManager = GameObject.FindObjectOfType<LevelManager>();
        //levelManager.LoadLevel("Gameover Screen");
    }
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");	
	}
    void Update()
    {
        if (GameObject.FindObjectsOfType<Ball>().Length == 0 && (GameObject.FindObjectsOfType<Ball2>().Length == 0 || GameObject.FindObjectsOfType<Ball3>().Length == 0))
        {
            print("Quitting");
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Gameover Screen");
        }
    }
	
}
