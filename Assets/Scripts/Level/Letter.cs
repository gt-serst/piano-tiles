using UnityEngine;

[System.Serializable]
public class Letter
{
	public string			letter;
	public LetterDisplay	display;
	private int				typeIndex;

	public Letter(string _letter, LetterDisplay _display)
	{
		letter = _letter;
		typeIndex = 0;

		display = _display;
		display.SetLetter(letter);
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
	public void MissedLetter()
	{
		typeIndex++;
		display.RemoveLetter(); //Remove the letter on screen
	}
	public void TypeWrongLetter()
	{
		display.ChangeLettersColor();
	}
	public void LetterTyped()
	{
		if (typeIndex >= letter.Length)
			display.RemoveWord();
	}
}
