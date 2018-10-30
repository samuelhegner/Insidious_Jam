using UnityEngine;


public class GAME_MANAGER : MonoBehaviour {

     public static GAME_MANAGER GM;

     public float CurrentHealth;

     public float CurrentRage;

     public float HealthDecay;

     public bool InShadow;

     public float PlayerMaxhealth;

     public bool Raged;

     public float RageTarget;

     private void Start() {

          GM = this;


     }


     private void Update() {

          if (!Raged) {
               if (!InShadow) {

                    CurrentHealth -= HealthDecay * Time.deltaTime;
                    //Debug.Log("Decaying");
                    

               } else {
                    
                    if (CurrentHealth < PlayerMaxhealth)
                         CurrentHealth += HealthDecay * Time.deltaTime;
                    else
                         CurrentHealth = PlayerMaxhealth;

               }


          }
     }
}