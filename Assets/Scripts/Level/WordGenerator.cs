using UnityEngine;

public class WordGenerator : MonoBehaviour
{
	string []			wordList = {"toto", "tata", "tutu", "titi"};
	private static int	compteur = 0;
	public Word			word;

	void Start()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
		ReactWebController rwc = objs[0].GetComponent<ReactWebController>();
		if(rwc.userWords.ToArray().Length!=0)
			wordList = rwc.userWords.ToArray();
	}
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
