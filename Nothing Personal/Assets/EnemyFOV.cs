using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
	public GameObject enemy;
	public EnemyAI enemyScript;

	void Awake()
	{
		enemy = gameObject.transform.parent.gameObject;
		enemyScript = GetComponentInParent<EnemyAI>();
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			enemyScript.currentState = EnemyAI.States.pursuit;
			Debug.Log("IN FOV");
		}
	}
}
