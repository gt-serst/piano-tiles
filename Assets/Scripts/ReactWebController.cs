using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// that Script is used for the UserWordsFromReact Game Object, it won't be destroyed when changing scene and it keeps in memory the list of words the user has to type in the game
public class ReactWebController : MonoBehaviour
{
	public List<string> userWords = new List<string>();

	// it is used for retrieving a list of word (from the react server)
	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	public void SetWord (string word)
	{
		userWords.Add(word);
	}
}
