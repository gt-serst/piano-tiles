using UnityEngine;

[System.Serializable]
public class Word
{
	public string		word;
	public WordDisplay	display;
	private int			typeIndex;

	public Word(string _word, WordDisplay _display)
	{
		word = _word;
		typeIndex = 0;

		display = _display;
		display.SetWord(word);
	}
	public char GetNextLetter()
	{
		return (word[typeIndex]);
	}
	public void TypeLetter()
	{
		typeIndex++;
		display.RemoveLetter(); //Remove the letter on screen
	}
	public void TypeWrongLetter()
	{
		display.ChangeLettersColor();
	}
	public bool WordTyped()
	{
		if (typeIndex >= word.Length)
		{
			display.RemoveWord();
			return (true);
		}
		else
			return (false);
	}
}
