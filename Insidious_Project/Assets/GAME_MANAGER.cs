using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_MANAGER : MonoBehaviour {

	public float PLayerMaxhealth;

	public float CurrentHealth;

	public float CurrentRage;

	public float RageTarget;

	public bool Raged;

	public static GAME_MANAGER GM;
	
	void Start () {

		GM = this;



	}
	
	
}
