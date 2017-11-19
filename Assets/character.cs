using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour {

	public bool isJump = false;
	public bool isFlip = false;
	private Vector2 startingPosition;
	private AudioSource audioSource;
	//Audio clips in videos
	public AudioClip squirrelJump;
	public AudioClip acornCollect;

	Animator anim;



	// Use this for initialization
	void Start () {
		startingPosition = gameObject.transform.position;
		audioSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
 var speed = 12.0f;  // ...or whatever.



if (Input.GetKey("d")) {
	transform.localScale = new Vector3(8,8,8);
    transform.Translate(Vector2.right * speed * Time.deltaTime);
	isFlip = true;
}

if (Input.GetKey("a")) {

	transform.localScale = new Vector3(-8,8,8);
    transform.Translate(Vector2.left * speed * Time.deltaTime);
	isFlip = false;
	
}

if (Input.GetKeyDown("w") && isJump == false) {
   GetComponent<Rigidbody2D>().AddForce(new Vector2(0,16), ForceMode2D.Impulse);
	isJump = true;
	anim.SetTrigger("jumping");
}

	}


void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
		if (coll.gameObject.CompareTag("PickUp"))
                {
                     Debug.Log("I am touching coin");
					 audioSource.clip = acornCollect;
					 audioSource.Play();
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
					 anim.SetTrigger("death");
					 StartCoroutine(deathThing());
					 
                }

				if (coll.gameObject.CompareTag("leaf"))
                {
                     Debug.Log("I am touching the leaf");
					 isJump = true;
					 anim.SetTrigger("jumping");
					 audioSource.clip = squirrelJump;
					 audioSource.Play();
					 GetComponent<Rigidbody2D>().AddForce(new Vector2(0,26), ForceMode2D.Impulse);
                }

				if (coll.gameObject.CompareTag("breakbranch"))
                {
                     Debug.Log("I am touching the break branch");
					 isJump = false; 
					 Destroy(coll.gameObject, .6f);
					 
                }

				if (coll.gameObject.CompareTag("acorn"))
                {
                     Debug.Log("I am touching the acorn");
					 SceneManager.LoadScene("credits");
					 
                }
			
    }

	IEnumerator deathThing()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("projectBird");
    }
}
