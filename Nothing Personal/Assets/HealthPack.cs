using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			HealthManager.instance.health++;
		}
	}
}
