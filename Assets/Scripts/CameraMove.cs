using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	public float scrollSpeed = 2f;
	public float zoomSpeed = 0.5f;
	public float maxY = 500f;
	public float minY = 90f;
	public float maxX = 500f;
	public float minX = 200f;
	private float maxZoom = 250f;
	private float minZoom = 100f;

	private Vector3 mouseDragOrigin;

	// Update is called once per frame
	void LateUpdate () {
		if ((transform.position.y >= minY && transform.position.y <= maxY) || 
			(transform.position.x >= minX && transform.position.x <= maxX)) {
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
					Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
					transform.Translate (0, -touchDeltaPosition.y * scrollSpeed, 0);
				}

				if (Input.touchCount == 2) {
					Touch touch0 = Input.GetTouch (0);
					Touch touch1 = Input.GetTouch (1);

					Vector2 touchPrevPos0 = touch0.position - touch0.deltaPosition;
					Vector2 touchPrevPos1 = touch1.position - touch1.deltaPosition;

					float prevTouchDeltaMag = (touchPrevPos0 - touchPrevPos1).magnitude;
					float touchDeltaMag = (touch0.position - touch1.position).magnitude;

					float deltaMag = prevTouchDeltaMag - touchDeltaMag;

					Camera.main.orthographicSize += deltaMag * zoomSpeed;
					Camera.main.orthographicSize = Mathf.Clamp (Camera.main.orthographicSize, minZoom, maxZoom);
				}
			} else {
				if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
					Debug.Log (Input.GetAxis("Mouse ScrollWheel").ToString());
					Camera.main.orthographicSize += Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
					Camera.main.orthographicSize = Mathf.Clamp (Camera.main.orthographicSize, minZoom, maxZoom);
				}

				if (Input.GetMouseButtonDown (0)) {
					mouseDragOrigin = Input.mousePosition;
					return;
				}

				if (!Input.GetMouseButton (0))
					return;

				Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseDragOrigin);
				
				Vector3 move = new Vector3 (pos.x * scrollSpeed, pos.y * scrollSpeed, 0);


				transform.Translate (move, Space.World);


			}

			if (transform.position.y < minY)
				transform.position = new Vector3 (transform.position.x, minY, transform.position.z);

			if (transform.position.y > maxY)
				transform.position = new Vector3 (transform.position.x, maxY, transform.position.z);

			if (transform.position.x < minX)
				transform.position = new Vector3 (minX, transform.position.y, transform.position.z);

			if (transform.position.x > maxX)
				transform.position = new Vector3 (maxX, transform.position.y, transform.position.z);
		}
	}
}
