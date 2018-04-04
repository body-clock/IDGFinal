using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	public float speed;
	public float rotSpeed;
	
	public float dir = 1;
	public float maxRotation;

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
		rotSpeed = 1f;
		maxRotation = 45f;
	}
	
	// Update is called once per frame
	void Update () {
			
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
		transform.Translate(localPosition.x * Time.deltaTime * speed, 0, localPosition.z * Time.deltaTime * speed);
		transform.LookAt(player.transform);
		transform.LookAt(2 * transform.position - player.transform.position);
	}
	
	void Idle()
	{
		
		Vector3 homePos = new Vector3(-.5f, 2.5f, -18);

		if (transform.position.z != homePos.z)
		{
			//go home
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, homePos, step);
		}
		else
		{
			//rotate in place and move back and forth
			transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * rotSpeed), 0f);
			transform.Translate(new Vector3(1,0,0) * Time.deltaTime * dir * speed, Space.World);
		}
		
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
