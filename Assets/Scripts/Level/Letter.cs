using UnityEngine;

[System.Serializable]
public class Letter
{
	public string		letter;
	public WordDisplay	display;
	private int			typeIndex;

	public Letter(string _letter, WordDisplay _display)
	{
		letter = _letter;
		typeIndex = 0;

		display = _display;
		display.SetWord(letter);
	}
	public char GetNextLetter()
	{
		return (letter[typeIndex]);
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
	public bool LetterTyped()
	{
		if (typeIndex >= letter.Length)
		{
			display.RemoveWord();
			return (true);
		}
		else
			return (false);
	}
}
