using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

	public float health;
	public float maxHealth = 100;

	public static HealthManager instance;

	// Use this for initialization
	void Start () {
		
		health = maxHealth;

		instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<RectTransform>().sizeDelta = new Vector2(health, 10);

		if (health <= 0)
		{
			health = 0;
			
			SceneManager.LoadScene("Death");
		}

		if (health>=100)
		{
			health = 100;
		}
			
		
	}
}
