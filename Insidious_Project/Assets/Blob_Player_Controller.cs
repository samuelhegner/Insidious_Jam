using UnityEngine;


public class Blob_Player_Controller : MonoBehaviour {

     public float forceScale;

     public bool InShadow;

     private bool shooting;
     
     private Rigidbody2D rb;


     // Use this for initialization
     private void Start() {

          rb = GetComponent<Rigidbody2D>();

//		rb.AddForce(new Vector2(-0.1f, -0.9f) * 20, ForceMode2D.Impulse );

     }


     private void FixedUpdate() {

          if (!shooting && Input.GetMouseButtonDown(0)) {

               Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

               var Direction = targetPos - (Vector2) transform.position;

               Direction.Normalize();

               rb.AddForce(Direction * forceScale, ForceMode2D.Impulse);

               shooting = true;



          }


          if (rb.velocity.magnitude <= 0.3f) {

               rb.velocity = Vector2.zero;
               shooting    = false;
               
          }


     }


     private void OnCollisionEnter2D(Collision2D other) {
          rb.velocity = Vector2.zero;
          shooting = false;
     }

     private void OnTriggerEnter2D(Collider2D other) {

          if (other.CompareTag("Shadow")) InShadow = true;

     }


     private void OnTriggerExit2D(Collider2D other) {

          if (other.CompareTag("Shadow")) InShadow = false;


     }
}