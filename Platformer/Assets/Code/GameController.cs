using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject myCanvas;

	public void ChangeToScene(int sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
	public void ChangeToScene(string sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
	public void DisableCanvas() {
		myCanvas.SetActive(false);
	}
	public void EnableCanvas()
	{
		myCanvas.SetActive(true);
	}

	public void pauseGame (){
		Time.timeScale = 0.0f;
	}
	public void resumeGame(){
		Time.timeScale = 1.0f;
	}
	public void exitGame(){
		Application.Quit();
	}
}

