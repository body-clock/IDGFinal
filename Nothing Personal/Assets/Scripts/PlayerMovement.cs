using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 7.0f; //movement speed
	public float tpDistance;
	public Vector3 startPos;

	public GameObject TPpos;
	private GameObject enemyRef;
	private EnemyAI enemyScript;

	public bool hasTeleported = false;

	public static PlayerMovement instance;
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked; //hides cursor when game plays
		tpDistance = 10;

		startPos = gameObject.transform.position;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {

		float forwardMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float sideMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate(sideMove, 0, forwardMove);

		if (Input.GetKeyDown(KeyCode.R))
		{
			Restart();
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("FOV"))
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				enemyRef = col.gameObject.transform.parent.gameObject;
				enemyScript = enemyRef.GetComponent<EnemyAI>();
				
				transform.Translate(0,0,TeleportDistance(enemyRef));
				
				enemyScript.currentState = EnemyAI.States.idle;
				hasTeleported = true;
			}
		}
	}

	public void Restart()
	{
		//reset position and set health back to 100
		gameObject.transform.position = startPos;
		HealthManager.instance.health = HealthManager.instance.maxHealth;
	}

	public float TeleportDistance(GameObject enemy)
	{
		//calculate consistent TP distance
		float dist = Vector3.Distance(transform.position, enemy.transform.position);
		dist += 3f;
		return dist;

	}
}
