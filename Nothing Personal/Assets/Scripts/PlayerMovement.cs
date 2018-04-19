﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 7.0f; //movement speed
	public float tpDistance;
	public Vector3 startPos;
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked; //hides cursor when game plays
		tpDistance = 10;

		startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		float forwardMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float sideMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate(sideMove, 0, forwardMove);

		if (Input.GetKeyDown(KeyCode.R))
		{
			Restart();
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("FOV"))
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				transform.Translate(0,0,tpDistance);
			}
		}
	}

	public void Restart()
	{
		gameObject.transform.position = startPos;
	}
}
