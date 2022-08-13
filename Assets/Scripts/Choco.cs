using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour, ConsumableInterface {
    private GameObject player;


    public void consumedBy(GameObject player) {
		// player.GetComponent<PlayerController>().upSpeed += 10;
		// StartCoroutine(removeEffect(player));
        
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")){
            // player = GameObject.Find("Player");
            // player.GetComponent<PlayerController>().takeCollisionDamage(-20);
            // Debug.Log(player.GetComponent<PlayerController>().health);

            Destroy(gameObject);
        }
    }

}