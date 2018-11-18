using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {

    public GameObject loadingText;

	// Use this for initialization
	void Start () {
        StartCoroutine(FlashText(loadingText));
        StartCoroutine(LoadScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Flashing loading screen
    IEnumerator FlashText(GameObject textObject) {
        while(true) {
            textObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            textObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Mimic a loading screen
    IEnumerator LoadScene() {
        if (GameController.scene == 1) {
            yield return new WaitForSeconds(1.5f);
            GameController.scene = 0;
            SceneManager.LoadScene("MainMenuScene");
        }
        else if (GameController.scene == 0) {
            yield return new WaitForSeconds(3f);
            GameController.scene = 1;
            SceneManager.LoadScene("GameScene");
        }
    }
}
