using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
	// ------ start variables to send to reactJS ------
	// start variables we are tracking to send to ReactJS when the game is finished. Doing so, we can store the results in our data base.
	private DateTime startingTime;
	private string text=""; // text that the user should have typed
	private string text_typed=""; // the text that the user has actually typed
	private bool is_letter_false=false; // We do not send that to ReactJS, but it is useful to store only once when an error is made on a letter. (if the user typed wrongly once the error, we only count it once)
	// ------ end variables to send to reactJS ------
	public List<Letter>		letters;
	public List<Word>		words;
	public WordGenerator	wordGenerator;
	public WordSpawner		wordSpawner;
	public Letter			currentLetter;
	public Word				currentWord;
	public bool				activeWord;
	public GameObject		wordObject;
	public GameObject		letterObject;
	public float			correctLetters = 0;
	public float			incorrectLetters = 0;
	public int				countLettersDisplayed = 0;

	void Start()
	{
		startingTime = DateTime.Now;
		AddWord();
		AddLetter();
	}
	private	void Update()
	{
		wordObject = GameObject.Find("Word(Clone)");
		letterObject = GameObject.Find("Letter(Clone)");

		if (!letterObject && countLettersDisplayed < wordGenerator.selectedWord.Length)
			AddLetter();
		if (letterObject)
			CheckOutliers();
	}

	public void CheckOutliers()
	{
		if (letterObject.transform.position.y <= -4f)
		{
			if(activeWord || is_letter_false){
				is_letter_false =false;
				// we have to add a space to mention a new word start when the word that the user was starting is deleted because out of zone
				// text = text + " " ;
				// text_typed = text_typed + " ";
			}
			if (activeWord)
			{
				currentLetter = letters[0];
				currentWord.MissedLetter();
				currentLetter.MissedLetter();
				letters.Remove(currentLetter);
				Destroy(letterObject);
			}
			else
			{
				activeWord = true;
				currentWord  = words[0];
				currentLetter = letters[0];
				currentWord.MissedLetter();
				currentLetter.MissedLetter();
				letters.Remove(currentLetter);
				Destroy(letterObject);
			}
			if (activeWord && currentWord.WordTyped())
			{
				activeWord = false;
				words.Remove(currentWord);
				AddWord();
				countLettersDisplayed = 0;
			}
		}
	}

	public void AddLetter()
	{
		Letter letter = new Letter(wordGenerator.GetNextLetter(), wordSpawner.SpawnLetter());
		letters.Add(letter);
		countLettersDisplayed++;
	}

	public void AddWord()
	{
		Word word = new Word(wordGenerator.GetNextWord(), wordSpawner.SpawnWord());
		words.Add(word);
	}

	public void TypeLetter(char letterTyped)
	{
		if (activeWord)
		{
			char letterToType = currentWord.GetNextLetter();
			currentLetter = letters[0];
			if (letterToType == letterTyped)
			{
				currentWord.TypeLetter();
				// remove letter
				currentLetter.TypeLetter();
				currentLetter.LetterTyped();
				letters.Remove(currentLetter);
				correctLetters++;
				if(!is_letter_false)
				{
					// the user typed correctly the letter on the first try
					text = text + letterToType; // word.GetNextLetter() was the correct letter to write
					text_typed = text_typed  + letterTyped; // letter is the correct letter that has been typed
				}
				else
				{
					// the user typed correctly the letter after typing it wrongly once or more
					is_letter_false=false;
				}
			}
			else
			{
				if(!is_letter_false)
				{
					currentWord.TypeWrongLetter();
					currentLetter.TypeWrongLetter();
					incorrectLetters++;
					is_letter_false = true;
					text = text + letterToType; // word.GetNextLetter() was the correct letter to write
					text_typed = text_typed  + letterTyped; // letter is the false letter that has been typed
				}
				else
				{
					// do nothing the first error has already be stored
				}
			}
		}
		else
		{
			currentWord = words[0];
			currentLetter = letters[0];
			char letterToType = currentWord.GetNextLetter();
			if (letterToType == letterTyped)
			{
				activeWord = true;
				currentWord.TypeLetter();
				// remove letter
				currentLetter.TypeLetter();
				currentLetter.LetterTyped();
				letters.Remove(currentLetter);
				correctLetters++;
				if(!is_letter_false)
				{
					// the user typed correctly the letter on the first try
					// between each word, we add a space to improve the readability (but not for the first word)
					if(text.Length!=0)
					{
						text = text + " " +letterToType;// correct_letter was the letter to type
						text_typed = text_typed + " "+letterTyped;// letter was the letter to type and it was correctly typed
					}
					else
					{
						text = text  +letterToType;// correct_letter was the letter to type
						text_typed = text_typed +letterTyped;// letter was the letter to type and it was correctly typed
					}
				}
				else
				{
					// the user typed correctly the letter after typing it wrongly once or more
					is_letter_false=false;
				}
			}
			else
			{
				if(!is_letter_false)
				{
					// the first time that is write wrongly the letter (of the new word in this case)
					incorrectLetters++;
					currentWord.TypeWrongLetter();
					currentLetter.TypeWrongLetter();
					if(text.Length!=0)
					{
						text = text +" "+ letterToType; // correct_letter was the correct letter to write
						text_typed = text_typed  +" "+ letterTyped; // letter is the false letter that has been typed
					}
					else
					{
						// if it's the first word, don't add the space
						text = text + letterToType; // correct_letter was the correct letter to write
						text_typed = text_typed  + letterTyped; // letter is the false letter that has been typed
					}
					is_letter_false=true;
				}
				else
				{
					// do nothing because the error has already been stored
				}
			}
		}
		if (activeWord && currentWord.WordTyped())
		{
			activeWord = false;
			words.Remove(currentWord);
			AddWord();
			countLettersDisplayed = 0;
		}
	}
	/* 3 methods to send results to GameManager when the game is finished, the results will be sent to ReactJS after that*/
	public string GetText()
	{
		return text;
	}

	public string GetTextTyped()
	{
		return text_typed;
	}

	public int GetDuration()
	{
		return (int)(((DateTime.Now-startingTime).TotalSeconds));
	}
}
