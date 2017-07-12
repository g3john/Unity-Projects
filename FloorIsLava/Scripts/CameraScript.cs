using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float offset;
    public GameObject player;
	// Use this for initialization
	void Start () {
        offset = transform.position.z - player.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset);

    }
}
