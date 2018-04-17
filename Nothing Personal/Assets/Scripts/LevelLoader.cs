using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

	private Object[] LevelButtonList;
	public GameObject buttonPrefab;
	public GameObject canvas;

	void Start()
	{
		LevelButtonList = Resources.LoadAll("Levels");
		Debug.Log(LevelButtonList.Length);
		
		LoadLevels();
	}

	public void LoadLevels()
	{
		foreach (var l in LevelButtonList)
		{
			GameObject button = Instantiate(buttonPrefab);
			button.transform.SetParent(canvas.transform);
		}
	}
	
	
}
