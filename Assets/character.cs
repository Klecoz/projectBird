using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour {

	public bool isJump = false;
	private Vector2 startingPosition;

	// Use this for initialization
	void Start () {
		startingPosition = gameObject.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
 var speed = 12.0f;  // ...or whatever.



if (Input.GetKey("d")) {
    transform.Translate(Vector2.right * speed * Time.deltaTime);
}

if (Input.GetKey("a")) {
    transform.Translate(Vector2.left * speed * Time.deltaTime);
}

if (Input.GetKeyDown("w") && isJump == false) {
   GetComponent<Rigidbody2D>().AddForce(new Vector2(0,16), ForceMode2D.Impulse);
	isJump = true;
}

	}


void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
		if (coll.gameObject.CompareTag("PickUp"))
                {
                     Debug.Log("I am touching coin");
					 Destroy(coll.gameObject);
                }

			if (coll.gameObject.CompareTag("platform"))
                {
                     Debug.Log("I am touching the platform");
					  isJump = false; 
                }


			if (coll.gameObject.CompareTag("beehive"))
                {
                     Debug.Log("I am touching the beehive");
					 gameObject.transform.position = startingPosition;
                }

			if (coll.gameObject.CompareTag("deathLine"))
                {
                     Debug.Log("I am touching the kill Line");
					 SceneManager.LoadScene("projectBird");
                }

				if (coll.gameObject.CompareTag("leaf"))
                {
                     Debug.Log("I am touching the leaf");
					 isJump = true; 
					 GetComponent<Rigidbody2D>().AddForce(new Vector2(0,26), ForceMode2D.Impulse);
                }

				if (coll.gameObject.CompareTag("breakbranch"))
                {
                     Debug.Log("I am touching the break branch");
					 isJump = false; 
					 Destroy(coll.gameObject, .6f);
					 
                }
			
    }
}
