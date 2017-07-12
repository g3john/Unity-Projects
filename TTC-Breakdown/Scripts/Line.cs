using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour {

    public Player player;
    public Station station1;
    public Station station2;
	Renderer rend;
	public bool running;
    public int[] closureTimes;

	// Use this for initialization
	void Start () {
        running = true;
		rend = GetComponent<Renderer> ();
		rend.material.shader = Shader.Find ("Specular");
	}

	// Update is called once per frame
	void Update () {
		if (closureTimes.Contains (player.currentTime)) {
			rend.material.SetColor ("_Color", Color.red);
			running = false;
		} else {
			rend.material.SetColor ("_Color", Color.white);
			running = true;
		}
	}

    void OnMouseDown() {
        if(running == true) {
			if (player.currentStation == station1) {
				player.oldStation = station1;
				player.currentStation = station2;
				player.moveToStation();
			} else if (player.currentStation == station2) {
				player.oldStation = station2;
				player.currentStation = station1;
				player.moveToStation();
			}
            player.currentTime += 1;
        }
    }
}
