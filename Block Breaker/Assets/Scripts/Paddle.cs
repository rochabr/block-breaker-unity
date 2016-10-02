using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private bool autoPlay = false;
	private Ball ball;

	void Start(){
		ball = Object.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			Move ();
		} else {
			AutoPlay ();
		}
	}

	void Move(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;	

		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		//float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;	

		paddlePos.x = ball.transform.position.x;
		this.transform.position = paddlePos;
	}
}
