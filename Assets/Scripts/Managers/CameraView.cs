using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {
	public Transform target;
	//private Vector2 cameraPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (transform.position.y != target.position.y) {
			transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
		}
	}
}
