using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
	public List<Word>		words;

	public WordGenerator	wordGenerator;
	public WordSpawner		wordSpawner;
	public Word				currentWord;
	public bool				activeWord;
	public GameObject		objectToFind;

	void Start()
	{
		AddWord();
	}

	private	void Update()
	{
		objectToFind = GameObject.Find("Word(Clone)");
		if (objectToFind.transform.position.y <= -6.75f)
		{
			if (activeWord)
			{
				activeWord = false;
				words.Remove(currentWord);
				Destroy(objectToFind);
			}
			else
			{
				words.RemoveAt(0);
				Destroy(objectToFind);
			}
		}
/*
		GameObject [] Target = GameObject.FindGameObjectsWithTag("Word");
		foreach (GameObject item in Target)
		{
			float tilesPosition = item.transform.position.y;
			if (tilesPosition <= -6.75f)
			{
				if (activeWord)
				{
					activeWord = false;
					words.Remove(currentWord);
					Destroy(item);
				}
				else
				{
					words.RemoveAt(0);
					Destroy(item);
				};
			}
		}
*/
	}

	public void AddWord()
	{
		Word word = new Word(wordGenerator.GetNextWord(), wordSpawner.SpawnWord());
		words.Add(word);
	}

	public void TypeLetter(char letter)
	{
		if (activeWord)
		{
			char currentLetter = currentWord.GetNextLetter();

			if (currentLetter == letter)
				currentWord.TypeLetter();
		}
		else
		{
			foreach (Word word in words)
			{
				char currentLetter = word.GetNextLetter();
				Debug.Log(currentLetter);

				if (currentLetter == letter)
				{
					currentWord = word;
					activeWord = true;
					word.TypeLetter();
				}
				break;
			}
		}
		if (activeWord && currentWord.WordTyped())
		{
			activeWord = false;
			words.Remove(currentWord);
		}
	}
}
