using UnityEngine;

public class WordGenerator : MonoBehaviour
{
	string []			wordList = {"titi", "tutu", "toto", "tata"};
	private static int	compteur = 0;

	public string GetNextWord()
	{
		string nextWord;

		if (compteur <= wordList.Length - 1)
		{
			nextWord = wordList[compteur];
			compteur++;
		}
		else
		{
			compteur = 0;
			nextWord = wordList[compteur];
			compteur++;
		}
		return nextWord;
	}
}
