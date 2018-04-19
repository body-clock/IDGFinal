using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCollider : MonoBehaviour
{

	public GameObject player;
	public PlayerMovement pm;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		pm = player.GetComponent<PlayerMovement>();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			 pm.Restart();
		}
	}
}
