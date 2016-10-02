using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;
	public static int breakableCount = 0;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			//increasing the number of breakable bricks in the scene
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits(){
		timesHit = timesHit + 1;	

		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			//decreasing number of breakable objects
			breakableCount--;
			levelManager.BrickDestroyed ();

			PuffSmoke ();
			Destroy (gameObject);
		} else {
			LoadSprite ();
		}
	}

	void PuffSmoke ()
	{
		GameObject destroySmoke = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		destroySmoke.GetComponent<ParticleSystem> ().startColor = GetComponent<SpriteRenderer> ().color;
	}

	private void LoadSprite(){
		if (hitSprites.Length >= timesHit) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [timesHit - 1];
		}
	}
}
