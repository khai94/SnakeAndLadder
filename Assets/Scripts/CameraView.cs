using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {
	public Transform target;
	//private Vector2 cameraPos;

	// Use this for initialization
	void Start () {
		//cameraPos = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x != target.position.x || transform.position.y != target.position.y) {
			transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
		}
	}
}
