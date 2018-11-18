using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;

    private GameObject player;
    private GameObject playerObject;
    private PlayerController playerController;

    private bool isGrounded;

    // Use this for initialization
    void Start () {
        isGrounded = true;
        StartCoroutine(Jump());
        player = GameObject.Find("Player");
        playerObject = GameObject.Find("Player/PlayerObject");
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(transform.position, playerObject.transform.position);

        // Instead of using collision detection, using distance from centre of ball object to player
        if (distance <= 1.45f) {
            player.GetComponent<PlayerController>().isDead = true;
            Time.timeScale = 1f;
        }
	}

    // Determines the grounded status through overlap with the layer mask
    void UpdateGroundedStatus() {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
    }

    IEnumerator Jump() {
        while (true) {
            if (isGrounded) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
                yield return new WaitForSeconds(0.7f);
            }
            else {
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
