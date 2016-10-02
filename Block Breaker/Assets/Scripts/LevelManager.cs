using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
		Brick.breakableCount = 0;
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
}
