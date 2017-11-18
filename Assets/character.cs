using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	public bool isJump = false;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
 var speed = 3.0f;  // ...or whatever.



if (Input.GetKey("d")) {
    transform.Translate(Vector2.right * speed * Time.deltaTime);
}

if (Input.GetKey("a")) {
    transform.Translate(Vector2.left * speed * Time.deltaTime);
}

if (Input.GetKeyDown("w") && isJump == false) {
   GetComponent<Rigidbody2D>().AddForce(new Vector2(0,16), ForceMode2D.Impulse);
   isJump = true;
   StartCoroutine(timeJump());
}

	}

	IEnumerator timeJump()
    {
        yield return new WaitForSeconds(1);
        isJump = false;
    }

void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
		if (coll.gameObject.CompareTag("PickUp"))
                {
                     Debug.Log("I am touching coin");
					 Destroy(coll.gameObject);
                }
    }
}
