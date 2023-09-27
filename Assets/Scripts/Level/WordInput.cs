using UnityEngine;

public class WordInput : MonoBehaviour
{
	public GameManager	gameManager;
	public WordManager	wordManager;

	void Update()
	{
		foreach(char letter in Input.inputString)
		if (!gameManager.finished)
			wordManager.TypeLetter(letter);
	}
}