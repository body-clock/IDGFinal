using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	//speeds
	public float speed;
	public float rotSpeed;
	
	public float dir = 1;
	public float maxRotation;

	public GameObject player;

	public Vector3 homePos;
	public float buffer = 1f;

	//our different states
	public enum States
	{
		idle,
		pursuit,
		damaging
	};

	public States currentState;

	void Awake()
	{
		//establish our enemy home position//allows us to spawn and enemy and
		//he knows where his home is regardless
		homePos = transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start()
	{	
		speed = 5f;
		rotSpeed = 1f;
		maxRotation = 45f;
	}
	
	// Update is called once per frame
	void Update () {
			
		CheckDistance();

		//switching between our states
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
		//bounce between walls
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
		HealthManager.instance.health-=.3f;
	}

	void CheckDistance()
	{
		float dist = Vector3.Distance(player.transform.position, transform.position);		

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
