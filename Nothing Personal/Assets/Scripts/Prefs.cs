using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prefs : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void NextScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
}
