using UnityEngine;

public class WordGenerator : MonoBehaviour
{
	string []			wordList = {"MAISON", "ARBRE", "LION", "FLEUR", "PATATE", "POUTRE", "BONBON"};
	public string 		selectedWord = "";
	int 				currentLetterIndex = 0;
	private static int	compteur = 0;
	public WordManager	wordManager;

	void Start()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
		ReactWebController rwc = objs[0].GetComponent<ReactWebController>();
		if(rwc.userWords.ToArray().Length!=0)
			wordList = rwc.userWords.ToArray();
	}

	public string GetNextWord(){
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
		selectedWord = nextWord;
		currentLetterIndex=0;
		return (selectedWord);
	}

	public string GetNextLetter()
	{
		// we take the next letter of the current word
		Debug.Log(selectedWord + " " + currentLetterIndex);
		if(currentLetterIndex<selectedWord.Length){
			string letter =  selectedWord[currentLetterIndex].ToString();
			currentLetterIndex=currentLetterIndex+1;
			Debug.Log(letter);
			return letter;
		}else{
			// we select a new word because previous word has been completely typed

			//wordManager.AddWord();
			string letter = selectedWord[currentLetterIndex].ToString();
			currentLetterIndex=currentLetterIndex+1;
			Debug.Log(letter);
			return letter;
		}
	}
}
