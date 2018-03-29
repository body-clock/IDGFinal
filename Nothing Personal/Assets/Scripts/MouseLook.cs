using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	private Vector2 mouseLook; //how much movement mouse has made
	private Vector2 smoothingV; //vector that will help smooth down mouse movement
	public float sensitivity = 4.0f; //sensitivity of mouseLook
	public float smoothing = 1.5f;

	GameObject character;
	
	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject;
	}
	
	void Update () {
		var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); //raw mouse input

		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing)); //
		smoothingV.x = Mathf.Lerp(smoothingV.x, mouseDelta.x, 1f / smoothing); //smooths down and lerps the mouse movement/camera
		smoothingV.y = Mathf.Lerp(smoothingV.y, mouseDelta.y, 1f / smoothing); //^
		mouseLook += smoothingV; //smooths down for adding to character rotation

		mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f); //prevents camera from looking too far down or up
		
		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); //changes the camera's up and down movement based on calculated mouseLook
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up); //changes both camera and character movement based on mouseLook

	}
}
