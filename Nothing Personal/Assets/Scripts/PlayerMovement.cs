using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 7.0f; //movement speed
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked; //hides cursor when game plays
	}
	
	// Update is called once per frame
	void Update () {

		float forwardMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float sideMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate(sideMove, 0, forwardMove);
	}
}
