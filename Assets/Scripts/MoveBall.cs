using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	void FixedUpdate() 
	{
		float moveSides = Input.GetAxis ("Horizontal");
		float moveBackForth = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveSides, 0, moveBackForth);

		rigidbody.AddForce (movement * 10, ForceMode.Force);
	}
}