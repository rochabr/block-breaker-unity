using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public AudioClip boing;

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		//sets our paddle object to the variable
		paddle = GameObject.FindObjectOfType<Paddle> ();
		//set the ball position + the addle position to the variable
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//Wait for the mouse press to launch
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				print ("Launch ball");
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		if (hasStarted) {
			//play audio boing
			Vector2 tweakVelocity = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));

			if (collision.collider.tag != "Breakable") {
				AudioSource.PlayClipAtPoint (boing, transform.position);
				GetComponent<Rigidbody2D> ().velocity += tweakVelocity;
			}
		}
	}
}
