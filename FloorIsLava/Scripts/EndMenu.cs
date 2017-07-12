using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//brings back the cursor so we can click on the button
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//function for returning to main menu
	public void PlayGame()
	{
		SceneManager.LoadScene ("FloorLava");
	}
}
