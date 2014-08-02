using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	private int blocks;
	private GameObject[] blocksArray;
	public static int activatedBlocks;
	public Material levelCompleteMaterial;
	private static bool _finishedLevel;
	private static int _currentLevel;
	private static bool _stopPlayer;

	public static void GoToNextLevel() {

	}

	public static void BackToMenu() {
		
	}

	public static bool IsPlayerStopped() {
		return _stopPlayer;
	}

	public static int GetCurrentLevel() {
		return _currentLevel;
	}

	public static bool LevelOver() {
		return _finishedLevel;
	}

	void Start() {
		_finishedLevel = false;
		blocksArray = GameObject.FindGameObjectsWithTag ("InactiveBlock");
		blocks = GameObject.FindGameObjectsWithTag("InactiveBlock").Length;
		activatedBlocks = 0;
		Debug.Log (blocks);
	}

	IEnumerator ChangeBlockColors() {
		_stopPlayer = true;
		foreach (GameObject block in blocksArray) {
			block.renderer.material = levelCompleteMaterial;	
			yield return new WaitForSeconds(0.1F);
		}
		_finishedLevel = true;
	}

	void Update() {
		if (activatedBlocks == blocks) {
			StartCoroutine(ChangeBlockColors());
			Debug.Log("Level Complete");		
		}
		if (_finishedLevel) {
			PauseGame();
		}
	}

	public static void PauseGame() {
		Time.timeScale = 0;
	}

	public static void UnPauseGame() {
		Time.timeScale = 1;
	}
}
