using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public GameObject targetObject;
    public GameObject[] objects;

    public bool isActive;

    private GameController gameControllerScript;
    private GameObject GameController;

	// Use this for initialization
	void Start () {
        GameController = GameObject.Find("GameController");
        gameControllerScript = GameController.GetComponent<GameController>();
        objects = gameControllerScript.objects;
        generateObject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Generates objects onto the game
    void generateObject() {
        int index = 0;
        float random = Random.Range(0f, 100.0f); // Chance of generating an object

        // Score threshold for introducing harder objects
        if(gameControllerScript.score > 50) {
            index = Random.Range(0, 7);
        }
        // Score threshold for introducing harder objects
        else if (gameControllerScript.score > 20) {
            index = Random.Range(0, 5);
        }
        else {
            index = Random.Range(0, 3);
        }
        
        GameObject curObject = (GameObject)Instantiate(objects[index]);
        curObject.transform.parent = transform;
        float randomX = Random.Range(-0.5f, 0.5f); // Randomly place the object's x-position
        Vector3 tmpPosition = transform.position;
        tmpPosition.x += randomX;
        curObject.transform.position = tmpPosition;

        // 40% of generating an object
        if(random <= 40.0f) { 
            isActive = true;
            curObject.SetActive(true);
        }
        else {
            isActive = false;
            curObject.SetActive(false);
        }
    }
}
