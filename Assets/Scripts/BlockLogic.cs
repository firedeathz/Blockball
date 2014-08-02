using UnityEngine;
using System.Collections;

public class BlockLogic: MonoBehaviour {
	
	public Material activeMaterial;
	private bool activated;

	private void ActivateBlock() {
		renderer.material = activeMaterial;
		tag = "ActiveBlock";
		GameLogic.activatedBlocks++;
		Debug.Log (GameLogic.activatedBlocks);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball") {
			ActivateBlock ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Ball") {
			activated = true;	
		}
	}
	
	void Update() {
		if (activated) {
			transform.position = Vector3.Lerp(transform.position,
			                                  new Vector3(transform.position.x,
			            					  			  0.0F,
			            								  transform.position.z),
			                                  Time.deltaTime*2.0F);
		}
	}
}
