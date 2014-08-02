using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	private int timePassed;
	private bool _countingTime;

	void Start() {
		timePassed = 0;
		_countingTime = false;
	}

	void OnGUI() {
		int roundedSeconds = timePassed;
		int displayMinutes = roundedSeconds / 60;
		int displaySeconds = roundedSeconds % 60;

		GUI.Label (new Rect(20, 10, 100, 20), "Time:");
		GUI.Label (new Rect(60, 10, 100, 20), string.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds));

		if (GameLogic.LevelOver ()) {
			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 100, 200, 120), "Level " + GameLogic.GetCurrentLevel() + " Complete!", "box");		
			if(GUI.Button(new Rect(Screen.width/2 - 90, Screen.height/2 - 60, 180, 20), "NextLevel", "button")) {
				GameLogic.GoToNextLevel();
			}
			if(GUI.Button(new Rect(Screen.width/2 - 90, Screen.height/2 - 20, 180, 20), "Back to Menu", "button")) {
				GameLogic.BackToMenu();
			}
		}
	}

	void Update() {
		if (!_countingTime) {
			StartCoroutine(CountTime());		
		}
	}

	IEnumerator CountTime() {
		_countingTime = true;
		timePassed++;
		yield return new WaitForSeconds (1);
		_countingTime = false;
	}
}
