using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollectable : MonoBehaviour {

	public float rageInc;
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Soul")) {

			//Destroy(other.gameObject);
			
			other.GetComponent<SoulRespawn>().Collected();

			GAME_MANAGER.GM.CurrentRage += rageInc;

		}
	}


}
