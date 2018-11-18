using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneController : MonoBehaviour {

    private int count = 0;
    private bool inStartPosition;

	// Use this for initialization
	void Start () {
        inStartPosition = false;
	}

    private void FixedUpdate() {
        Animate();
    }

    // Rotating animation
    void Animate()  {
        // Starting position of watermelon is in the middle. Full animation rotates from left to right to approximately a 45 degree angle and vice versa
        if(!inStartPosition) {
            if(count < 5) {
                transform.Rotate(Vector3.back * -5);
                count++;
            }
            else {
                count = 0;
                inStartPosition = true;
            }
        }
        else {
            if(count < 10) {
                transform.Rotate(Vector3.back * 5);
                count++;
            }
            else if(count < 20) {
                transform.Rotate(Vector3.back * -5);
                count++;
            }
            else {
                count = 0;
            }
        }
    }
}
