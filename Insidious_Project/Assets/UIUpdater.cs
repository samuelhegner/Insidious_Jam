using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

	public Slider HealthSlider;
	public Slider RageSlider;
	
	// Use this for initialization
	
IEnumerator Start () {

	yield return null;
	HealthSlider.maxValue = GAME_MANAGER.GM.PlayerMaxhealth;

	RageSlider.maxValue = GAME_MANAGER.GM.RageTarget * 2;



}
	
	// Update is called once per frame
	void Update () {

		HealthSlider.value = GAME_MANAGER.GM.CurrentHealth;
		RageSlider.value = GAME_MANAGER.GM.CurrentRage;


	}
}
