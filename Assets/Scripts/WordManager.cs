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

	private	void Update()
	{
		if (!GameObject.Find("Word(Clone)"))
			AddWord();
		else
		{
			CheckOutliers();
		}
	}

	public void CheckOutliers()
	{
		objectToFind = GameObject.Find("Word(Clone)");
			float tilesPosition = objectToFind.transform.position.y;
			if (tilesPosition <= -6.75f)
			{
				if (activeWord)
				{
					activeWord = false;
					words.Remove(currentWord);
					Destroy(objectToFind);
				}
				else
				{
					Destroy(objectToFind);
					words.RemoveAt(0);
				}
			}
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
			else
				currentWord.WrongLetter();

		}
		else
		{
			foreach (Word word in words)
			{
				char currentLetter = word.GetNextLetter();

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
