using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {
	public Transform target;
	//private Vector2 cameraPos;

	public void FollowTarget()
	{
		if (transform.position.y != target.position.y) {
			transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
		}
	}
}
