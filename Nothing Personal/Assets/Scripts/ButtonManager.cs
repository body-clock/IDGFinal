using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

	public IndividualButton Button;
	public List<GameObject> buttonList;

	// Use this for initialization
	void Start ()
	{

		foreach (Transform child in this.gameObject.transform)
		{
			buttonList.Add(child.gameObject);
		}	

	}

	private bool AreAllButtonsPressed()
	{
		for (int i = 0; i < buttonList.Count; i++)
		{
			if (buttonList[i].GetComponent<IndividualButton>().pressed == false)
			{
				return false;
			}
		}
		return true;
	}
	
	// Update is called once per frame
	void Update () {
		if (AreAllButtonsPressed())
		{
			Debug.Log("All pressed");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
