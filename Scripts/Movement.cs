using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


	private float dist;
	public bool dragging = false;
	public Vector3 offset;
	private Vector3 toDrag;

	void Update() {
		Vector3 v3;

		if (Input.touchCount != 1) {
			dragging = false; 
			return;
		}

		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;

		if(touch.phase == TouchPhase.Began) {
				
			toDrag = transform.position;
				dist = transform.position.z - Camera.main.transform.position.z;
				v3 = new Vector3(pos.x, pos.y, dist);
				v3 = Camera.main.ScreenToWorldPoint(v3);
				offset = toDrag - v3;
				dragging = true;
			}

		if (dragging && touch.phase == TouchPhase.Moved) {
			v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
			v3 = Camera.main.ScreenToWorldPoint(v3);
			transform.position = v3 + offset;
		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
			dragging = false;
		}
	}
}


