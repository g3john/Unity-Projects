using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public float myGravity;
    public float myBaseJumpHeight;
    public int score;
    private Rigidbody rb;
    public float speed;
    private float elapsedTime = 0f;
    private bool end;

    private bool isDown;
    // Use this for initialization
    void Start () {
        score = 0;
        myGravity = 0.0f;
        myBaseJumpHeight = 8.0f;
        rb = GetComponent<Rigidbody>();
        elapsedTime = Time.time;
        end = false;
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isJumpPressed = Input.GetButtonDown("Jump");
        Vector3 movement = new Vector3(moveHorizontal, 0 + myGravity, moveVertical);
        if (isJumpPressed && transform.position.y < 1.0f) {
            movement = new Vector3(moveHorizontal, myBaseJumpHeight + myGravity, moveVertical);
        }
        if (!end) 
        {
            score = (int)(Time.time - elapsedTime);
        }
        rb.AddForce(movement * speed);
        if (transform.position.y < -20) 
        {
            transform.position = new Vector3(0f, 1.1f, 0f);
            elapsedTime = Time.time;
        } 
    }
	void OnTriggerEnter(Collider other) {
        Debug.Log("Win");
        end = true;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), score.ToString());
    }
}
