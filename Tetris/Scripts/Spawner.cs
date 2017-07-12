﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] blocks; 
	// Use this for initialization
	void Start () {
        spawnNext();
	}
	
	public void spawnNext()
    {
        int i = Random.Range(0, blocks.Length);

        Instantiate(blocks[i],
            transform.position,
            Quaternion.identity);
    }
}
