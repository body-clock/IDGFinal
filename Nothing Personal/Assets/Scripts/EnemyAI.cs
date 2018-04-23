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

	public float startAngle;
	public float endAngle;

	private Vector3 startRotation;
	private Vector3 endRotation;

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
		
		startRotation = new Vector3(0, startAngle, 0);
		endRotation = new Vector3(0, endAngle, 0);
	}

	void Start()
	{	
		rotSpeed = 1f;
		maxRotation = 0.5f;
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

		transform.LookAt(player.transform);
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		

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
			RotateInPlace();
		}
		
	}

	void RotateInPlace()
	{		
		//PingPong between 0 and 1
		float time = Mathf.PingPong(Time.time * rotSpeed, 1);
		transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, time);
	}
	

	void Damaging()
	{
		//deal damage to player
		HealthManager.instance.health-=.3f;
	}

	void CheckDistance()
	{
		float dist = Vector3.Distance(player.transform.position, transform.position);		

		if (dist > 10f || PlayerMovement.instance.hasTeleported)
		{
			currentState = States.idle;
			PlayerMovement.instance.hasTeleported = false;
		}

		/*if (dist < 10f)
		{
			currentState = States.pursuit;
		}*/

		if (dist < 2f)
		{
			currentState = States.damaging;
		}
	}
	

}
