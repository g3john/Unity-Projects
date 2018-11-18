using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;

    public float jump = 300.0f;
    public float hop = 20.0f;
    public bool isDead = false;
    public float score = 0;
    
    private GameObject gameController;
    private GameObject PlayerObject;
    private GameController gameControllerScript;
    private Rigidbody2D playerRigidbody;
    
    private bool isGrounded;
    private bool isJumping = false;
    private float forwardMovementSpeed = 5.0f;
    private int[] scoreThreshold = { 20, 50 };
    private int currentThreshold = 0;

	// Use this for initialization
	void Start () {
        isGrounded = true;
		playerRigidbody = GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.Find("Player/PlayerObject");
        gameController = GameObject.Find("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();

        StartCoroutine(Hop());

        // The player has two colliders, one for the camera to stay on while hopping, the other for the hopping pupper
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), PlayerObject.GetComponent<CircleCollider2D>());
	}

    void Update() {
        StartCoroutine(DetectJump());
        UpdateGroundedStatus();
    }

    void FixedUpdate () {
        score = gameControllerScript.score;
        if (!isGrounded || isJumping) {
            PlayerObject.transform.position = transform.position; // Keeps the two player gameObjects together when in the air
        }
        if (!isDead) {
            // Moves the player in a constant speed
            Vector2 newVelocity = playerRigidbody.velocity;
            newVelocity.x = forwardMovementSpeed;
            playerRigidbody.velocity = newVelocity;

            newVelocity = PlayerObject.GetComponent<Rigidbody2D>().velocity;
            newVelocity.x = forwardMovementSpeed;
            PlayerObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        else {
            // Death animation
            transform.Rotate (Vector3.back * -10);
        }
        UpdateSpeed();
        
	}

    // Increase speed at score thresholds
    void UpdateSpeed() {
        if (currentThreshold == 0 && score >= scoreThreshold[0]) {
            currentThreshold++;
            Time.timeScale = Time.timeScale * 1.25f;
        }
        else if (currentThreshold == 1 && score >= scoreThreshold[1]) {
            currentThreshold++;
            Time.timeScale = Time.timeScale * 1.25f;
        }
    }

    // Death on collision of objects
    void OnTriggerEnter2D(Collider2D collider) {
        isDead = true;
        Time.timeScale = 1f;
    }

    // Checks if player is grounded
    void UpdateGroundedStatus() {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
    }

    // Detect player clicks/taps
    IEnumerator DetectJump() {   
        bool clickedJump = Input.GetButtonDown("Fire1");
        if (clickedJump && !isDead && isGrounded && !isJumping) {
            isJumping = true;
            PlayerObject.transform.position = transform.position; // Pupper sprite is hopping. This puts it back with the other object before jumping
            playerRigidbody.AddForce(new Vector2(0, jump));
            PlayerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            yield return new WaitForSeconds(0.25f); // Prevent jumping twice after jumping already
            isJumping = false;
        }
        
    }

    // Hopping animation
    IEnumerator  Hop() {
        while (!isDead) {
            if (isGrounded) {
                PlayerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, hop));
                yield return new WaitForSeconds(0.4f);
            }
            else {
                yield return new WaitForSeconds(0.4f);
            }
            PlayerObject.transform.position = transform.position; // Keeps playerObjects together
        }
    }
}
