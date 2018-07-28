using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {
	public Transform target;
    //private Vector2 cameraPos;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        transform.position = transform.position = new Vector3(transform.position.x, transform.position.y, -80f);
    }

    /*
    public void FollowTarget()
	{
		if (transform.position.y != target.position.y) {
            //transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
            //transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
	}
    */
}
