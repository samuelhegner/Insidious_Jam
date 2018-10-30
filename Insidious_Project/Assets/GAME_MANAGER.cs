using UnityEngine;
using UnityEngine.SceneManagement;


public class GAME_MANAGER : MonoBehaviour {

     public static GAME_MANAGER GM;

     public float CurrentHealth;

     public float CurrentRage;

     public float HealthDecay;

     public bool InShadow;

     public float PlayerMaxhealth;

     public static bool Raged;

     public float RageTarget;


     public GameObject BlobPlayer;
     public GameObject RagePlayer;

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
                         CurrentHealth += HealthDecay * 3  * Time.deltaTime;
                    else
                         CurrentHealth = PlayerMaxhealth;

               }

               if (CurrentRage >= RageTarget) {

                    changeForm();
                    
                    
                    
               }




          } else {


               CurrentRage -= HealthDecay * Time.deltaTime;

               if (CurrentRage <= 0f) {

                    CurrentRage = 0;
                    
                    changeForm();

               }


          }



          if (CurrentHealth <= 0f) {

               //todo: GO COMMIT DIE
               
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
               
               
          }

     }

     private void changeForm() {

          if (Raged) {


               BlobPlayer.transform.position = RagePlayer.transform.position;

               BlobPlayer.SetActive(true);
               RagePlayer.SetActive(false);

          } else {

               RagePlayer.transform.position = BlobPlayer.transform.position;

               BlobPlayer.SetActive(false);
               RagePlayer.SetActive(true);
               
          }


          Raged = !Raged;


     }

     

}