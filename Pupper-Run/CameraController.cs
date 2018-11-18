using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject targetObject;

    public float cameraOffsetX = 1.0f;
    public float cameraOffsetY = 5.0f;

    private GameObject playerObject;
    private PlayerController playerController;

    private bool isPlayerDead = false;
    

	// Use this for initialization
	void Start () {
        playerObject = GameObject.Find("Player");
        playerController = playerObject.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        isPlayerDead = playerController.isDead;
        if (!isPlayerDead) {
            UpdateCameraPosition();
        }
	}

    // Move camera with player object
    private void UpdateCameraPosition() {
        float targetObjectX = targetObject.transform.position.x + cameraOffsetX;
        float targetObjectY = targetObject.transform.position.y + cameraOffsetY;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + cameraOffsetX;
        newCameraPosition.y = targetObjectY + cameraOffsetY;
        transform.position = newCameraPosition;
    }
}
