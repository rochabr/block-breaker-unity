using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;

	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision){
		if (this.tag == "Breakable") {
			HandleHits ();
		}
	}

	void HandleHits(){
		timesHit = timesHit + 1;	

		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			LoadSprite ();
		}
	}

	private void LoadSprite(){
		if (hitSprites.Length >= timesHit) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [timesHit - 1];
		}
	}
}
