using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
	public float strength;

	private Rigidbody rb;

	void OnTriggerEnter(Collider col)
	{
		rb = col.gameObject.GetComponent<Rigidbody>();
		rb.velocity = Vector3.up * strength;
	}
}
