using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonController : MonoBehaviour {

    private int count = 0;
    private bool inStartPosition;

	// Use this for initialization
	void Start () {
		inStartPosition = false;
	}
	
	// Update is called once per frame
	void Update () {
        Animate();
    }

    // Swinging animation
    void Animate() {
        // Starting position of watermelon is in the middle. Full animation swings from left to right and vice versa
        if(!inStartPosition) {
            if (count < 12) {
                transform.Translate(-.02f, 0, 0);
                transform.Rotate(Vector3.back * -1.5f);
                count++;
            }
            else {
                count = 0;
                inStartPosition = true;
            }
        }
        else {
            if (count < 24) {
                transform.Translate(.02f, 0, 0);
                transform.Rotate(Vector3.back * 1.5f);
                count++;
            }
            else if (count < 48) {
                transform.Translate(-.02f, 0, 0);
                transform.Rotate(Vector3.back * -1.5f);
                count++;
            }
            else {
                count = 0;
            }
        }
    }
}
