using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stim : MonoBehaviour, ConsumableInterface {
    private GameObject player;


    public void consumedBy(GameObject player) {
		// player.GetComponent<PlayerController>().upSpeed += 10;
		// StartCoroutine(removeEffect(player));
        
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")){
            player = GameObject.Find("Player");
            player.GetComponent<PlayerController>().runSpeed += 0.1f;
            Debug.Log(player.GetComponent<PlayerController>().runSpeed);
            
            Destroy(gameObject);
        }
    }

}