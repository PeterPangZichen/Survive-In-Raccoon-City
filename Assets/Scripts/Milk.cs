using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour, ConsumableInterface {
    public void consumedBy(GameObject player) {
		// player.GetComponent<PlayerController>().upSpeed += 10;
		// StartCoroutine(removeEffect(player));
        
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }

}