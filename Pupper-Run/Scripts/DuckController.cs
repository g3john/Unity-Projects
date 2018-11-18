using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {

    private GameObject bubble;
    private GameObject bubblePop;
    private int count = 0;
    private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		bubble = transform.GetChild(1).gameObject;
        bubblePop = transform.GetChild(2).gameObject;
        bubble.SetActive(true);
        bubblePop.SetActive(false);
        originalPosition = bubble.transform.position;
        StartCoroutine(Animate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Bubble floating/popping
    private IEnumerator Animate()  {
        while (true) {

            // Floating
            if (count < 10) {
                bubble.transform.Translate(0, 0.1f, 0);
                yield return new WaitForSeconds(0.1f);
                count++;
            }

            // Pop
            else {
                bubblePop.SetActive(true);
                bubblePop.transform.position = bubble.transform.position;
                bubble.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                float randomX = Random.Range(-0.8f, 0.5f);
                bubble.SetActive(true);
                Vector3 tmpPosition = originalPosition;
                tmpPosition.x = tmpPosition.x + randomX;
                bubble.transform.position = tmpPosition;
                bubblePop.SetActive(false);
                count = 0;
            }
        }
        
    }
}
