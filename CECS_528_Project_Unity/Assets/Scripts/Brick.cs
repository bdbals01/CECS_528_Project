using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
    private GameObject ball;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
        ball = GameObject.Find("Ball");
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
		if (isBreakable) {
			HandleHits(col);
		}
	}
	
	void HandleHits (Collision2D col) {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
            PowerUp(col);
			levelManager.BrickDestoyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
		}
	}
	
	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
    void PowerUp(Collision2D col)
    {
        var number = Random.Range(1, 20);
        if(number >1 && number < 5)
        {
            GameObject newball = (GameObject)Instantiate(col.gameObject);
            if (col.gameObject.name.StartsWith("Ball 2"))
            {
                newball.transform.localPosition = col.gameObject.transform.localPosition;
            }
            if (col.gameObject.name.StartsWith("Ball 2"))
            {
                newball.transform.localPosition = col.gameObject.transform.localPosition;
            }
            else
            {
                newball.transform.localPosition = this.transform.localPosition;
            }
            
        }
        else if (number > 16 && number <20)
        {
            print("ChangingSize" );
            if(col.gameObject.name.StartsWith("Ball 2"))
            {
                col.transform.localScale = new Vector3(.75f, .75f, .75f);
            }
            else
            {
                col.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            
        }
        
    }
}
