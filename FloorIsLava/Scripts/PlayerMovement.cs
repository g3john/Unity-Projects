using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    //public GameObject jumpArea;
    private bool hasControl;
    public float myBaseJumpHeight;
    public float gravity;
    CharacterController controller;
    SphereCollider collider;
    private float distToGround;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        collider = GetComponent<SphereCollider>();
        hasControl = true;
        gravity = 0.0f;
        myBaseJumpHeight = 20.0f;
        distToGround = collider.bounds.extents.y;
	}

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!hasControl)
            return;
		float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool jumpPressed = Input.GetButtonDown("Jump");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (jumpPressed && IsGrounded()) {
            movement = new Vector3(moveHorizontal, myBaseJumpHeight + gravity, moveVertical);
        }

        rb.AddForce(movement * speed);
	}

    /*void OnTriggerEnter(Collider area) {
        Debug.Log("Trigger");
        rb.AddForce(new Vector3(0.0f, 10.0f * speed, 0.0f));
        //hasControl = false;
    }*/
}
