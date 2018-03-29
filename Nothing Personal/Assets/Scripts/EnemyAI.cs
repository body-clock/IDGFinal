using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	public float speed;
	public float dir = 1;

	void Start()
	{
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(new Vector3(1,0,0) * Time.deltaTime * dir * speed);
		
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			dir *= -1;
		}
	}
}
