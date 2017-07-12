using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Station oldStation;
    public Station currentStation;
    public int currentTime;
	public Transform newTransform;

	public float speed;

	public void moveToStation() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(currentStation.transform.position, oldStation.transform.position, step);
		transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
	}
}
