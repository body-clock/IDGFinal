using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualButton : MonoBehaviour
{
	public Renderer rend;
	public bool pressed = false;

	void Awake()
	{
		rend = GetComponent<Renderer>();
		rend.material.color = Color.red;
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				SwitchMaterial();
				Debug.Log("material switch");
			}
		}
	}

	void SwitchMaterial()
	{
		if (rend.material.color == Color.red)
		{
			rend.material.color = Color.green;
			pressed = true;
		}
		else
		{
			rend.material.color = Color.red;
			pressed = false;
		}
	}
}
