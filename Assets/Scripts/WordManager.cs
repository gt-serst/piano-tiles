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
			{
				currentWord.TypeLetter();
			}
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
			}
		}
		if (activeWord && currentWord.WordTyped())
		{
			activeWord = false;
			words.Remove(currentWord);
		}
	}
}
