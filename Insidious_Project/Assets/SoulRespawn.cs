using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulRespawn : MonoBehaviour {

     public float timeToRespawn;
     
     public void Collected() {


          StartCoroutine(respawn());

     }



     IEnumerator respawn() {

          GetComponent<Collider2D>().enabled = false;
          transform.GetChild(0).gameObject.SetActive(false);
          
          yield return  new WaitForSeconds(timeToRespawn);


          GetComponent<Collider2D>().enabled = true;
          transform.GetChild(0).gameObject.SetActive(true);


     }
}
