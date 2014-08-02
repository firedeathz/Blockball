using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	/*
	This camera smoothes out rotation around the y-axis and height.
	Horizontal Distance to the target is always fixed.

	There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

	For every of those smoothed values we calculate the wanted value and the current value.
	Then we smooth it using the Lerp function.
	Then we apply the smoothed values to the transform's position.
	*/
	
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0F;
	// the height we want the camera to be above the target
	public float height = 12.0F;
	// How much we 
	public float heightDamping = 2.0F;
	
	void Update () {
		// Early out if we don't have a target
		if (!target)
			return;

		float wantedHeight = target.position.y + height;
		float currentHeight = transform.position.y;

		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= Vector3.forward * distance;
		
		// Set the height of the camera
		transform.position += new Vector3 (0,currentHeight - transform.position.y,0);

		// Always look at the target
		transform.LookAt (target);
	}
}
