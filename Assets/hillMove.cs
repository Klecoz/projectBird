﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hillMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("d")) {
		transform.Translate(-Vector3.right * .8f * Time.deltaTime);
		}

		if (Input.GetKey("a")) {
		transform.Translate(-Vector3.left * .8f * Time.deltaTime);
		}
	}
}
