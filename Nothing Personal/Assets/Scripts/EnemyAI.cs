using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	public float speed;
	public float dir = 1;

	public GameObject player;

	public enum States
	{
		idle,
		pursuit,
		damaging
	};

	public States currentState;

	void Start()
	{	
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.Translate(new Vector3(1,0,0) * Time.deltaTime * dir * speed);
		
		CheckDistance();

		switch (currentState)
		{
			case States.idle:
				Idle();
				break;
			case States.pursuit:
				Pursuit();
				break;
			case States.damaging:
				Damaging();
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			dir *= -1;
		}
	}

	void Pursuit()
	{
		//follow player
		Vector3 localPosition = player.transform.position - transform.position;
		localPosition = localPosition.normalized;
		transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
	}
	
	void Idle()
	{
		//rotate in place
	}

	void Damaging()
	{
		//deal damage to player
	}

	void CheckDistance()
	{
		float dist = Vector3.Distance(player.transform.position, transform.position);
		
		Debug.Log(dist);
		

		if (dist > 10f)
		{
			currentState = States.idle;
		}

		if (dist < 10f)
		{
			currentState = States.pursuit;
		}

		if (dist < 5f)
		{
			currentState = States.damaging;
		}
	}
}
