using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public AudioSource bgm;

    public static string character;

    private GameObject MainMenu;
    private GameObject ChooseCharacter;
    private GameObject Credits;

	void Start () {
        MainMenu = GameObject.Find("Canvas/MainMenu");
        ChooseCharacter = GameObject.Find("Canvas/ChooseCharacter");
        Credits = GameObject.Find("Canvas/Credits");
        MainMenu.SetActive(true);
        ChooseCharacter.SetActive(false);
        Credits.SetActive(false);
    }

    // Choose your pupper
    public void StartGame() {
        MainMenu.SetActive(false);
        ChooseCharacter.SetActive(true);
    }

    // Credits
    public void CreditsPage() {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    // Back to main menu
    public void MainMenuPage() {
        MainMenu.SetActive(true);
        ChooseCharacter.SetActive(false);
        Credits.SetActive(false);
    }

    // When choosing the pupper, we set the character to show the sprite in the game scene
    public void choosePam() {
        character = "Pam";
        SceneManager.LoadScene("LoadingScene");
    }

    public void chooseDeb() {
        character = "Deb";
        SceneManager.LoadScene("LoadingScene");
    }

    public void chooseGus() {
        character = "Gus";
        SceneManager.LoadScene("LoadingScene");
    }
}
