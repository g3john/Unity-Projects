using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] availableStairs;
    public GameObject[] objects;
    public List<GameObject> currentStairs;
    public GameObject player;
    public Text scoreLabel;
    public Text gameOverScoreLabel;
    public AudioSource bgm;

    public float speed = 1.0f;
    public float stairWidth = 2.85f;
    public float stairHeight = 1.3375f;
    public static int scene = 0;
    public int score = 0;

    private GameObject playerObject;
    private GameObject pam;
    private GameObject deb;
    private GameObject gus;
    private GameObject gameOverObject;
    private GameObject scoreObject;
    private PlayerController playerController;

    private float screenWidthInPoints;
    private bool isDead;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        scoreObject = GameObject.Find("Canvas/ScoreObject");
        scoreObject.SetActive(true);

        gameOverObject = GameObject.Find("Canvas/GameOverObject");
        gameOverObject.SetActive(false);

        isDead = playerController.isDead;
        scoreLabel.text = "Score: 0";
        gameOverScoreLabel.text = "Score 0";

        StartCoroutine(GeneratorCheck());
        StartCoroutine(ScoreIncrement());
        HandleCharacterChoice();

		float width = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = width * Camera.main.aspect;
    }
	
	// Update is called once per frame
	void Update () {
		isDead = playerController.isDead;
        if (isDead)  {
            bgm.Stop();
            scoreObject.SetActive(false);
            gameOverObject.SetActive(true);
        }
	}

    // Increase score every Time.deltaTime * second
    private IEnumerator ScoreIncrement() {
        while (!isDead)
        {
            yield return new WaitForSeconds(1f);
            if (!isDead)
            {
                score++;
                scoreLabel.text = "Score: " + score.ToString();
                gameOverScoreLabel.text = "Score: " + score.ToString();
            }
        }
    }

    // Loop adding/removing stairs
    private IEnumerator GeneratorCheck() {
        while (!isDead)
        {
            GenerateStairsIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }

    // Logic for generating staircase
    private void GenerateStairsIfRequired() {
        float playerX = player.transform.position.x;
        float addStairsX = playerX + screenWidthInPoints;
        float removeStairsX = playerX - screenWidthInPoints;

        // Add Stairs
        GameObject stairs = currentStairs[currentStairs.Count-1];
        float stairsWidth = stairs.transform.position.x;
        float stairsHeight = stairs.transform.position.y;
        float stairsStartX = stairs.transform.position.x - (stairsWidth / 8f);
        float stairsEndX = stairs.transform.position.x + ((stairsWidth * 7f) / 8f);

        if (stairsStartX <= addStairsX) {
            AddStairs(stairsWidth + 11.3952f, stairsHeight + 3.2f);
        }
        
        // Remove stairs
        stairs = currentStairs[0];
        stairsWidth = stairs.transform.position.x;
        stairsStartX = stairs.transform.position.x - (stairsWidth / 8f);
        stairsEndX = stairs.transform.position.x + ((stairsWidth * 7f) / 8f);
        
        // Player screen is far enough to remove stairs
        if (stairsEndX < removeStairsX) {
            currentStairs.Remove(stairs);
            Destroy(stairs);
        }
    }

     // Add staircase prefab when player screen reaches near the end of the current list of staircases
    void AddStairs(float farthestStairsEndX, float farthestStairsEndY) {
        int randomStairsIndex = Random.Range(0, availableStairs.Length);
        GameObject stairs = (GameObject)Instantiate(availableStairs[randomStairsIndex]);
        stairs.transform.position = new Vector3(farthestStairsEndX, farthestStairsEndY, 0);
        currentStairs.Add(stairs);
    }

    void HandleCharacterChoice() {
        pam = GameObject.Find("Player/PlayerObject/Pam");
        deb = GameObject.Find("Player/PlayerObject/Deb");
        gus = GameObject.Find("Player/PlayerObject/Gus");

        pam.SetActive(false);
        deb.SetActive(false);
        gus.SetActive(false);

        string character = MainMenuController.character;

        // Set pupper sprite based on chosen character
        if (character == "Pam") {
            pam.SetActive(true);
        }
        else if (character == "Deb") {
            deb.SetActive(true);
        }
        else if (character == "Gus") {
            gus.SetActive(true);
        }
        else {
            gus.SetActive(true);
        }
    }

    public void PlayAgain() {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu() {
        SceneManager.LoadScene("LoadingScene");
    }
}
