using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


// that Script is used for the UserWordsFromReact Game Object, it won't be destroyed when changing scene and it keeps in memory the list of words the user has to type in the game
public class ReactWebController : MonoBehaviour
{
	public List<string> userWords = new List<string>();
	public List<TMP_FontAsset> userFonts = new List<TMP_FontAsset>();
	public TMP_FontAsset userFont;
	public int userFontSize;

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
	public void SetParams(string font, int fontSize)
	{
		if (font == "Comic Sans MS")
			userFont = userFonts[0];
		else if (font == "Arial")
			userFont = userFonts[1];
		else if (font == "Trebuchet MS")
			userFont = userFonts[2];
		else if (font == "Century Gothic")
			userFont = userFonts[3];
		userFontSize = fontSize;
	}
}
