using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public		GameObject wordPrefab;
	public		GameObject letterPrefab;
	public		Transform wordCanvas;
	public		GameObject Collider;
	public int	count = 0;

	public LetterDisplay SpawnLetter()
	{
		float[]	tilesPosition = {-3f, -1f, 1f, 3f};
		int randomIndex = Random.Range(0, tilesPosition.Length);
		Vector3 randomPosition = new Vector3(tilesPosition[randomIndex], 9.5f);
		GameObject letterObj = Instantiate(letterPrefab, randomPosition, Quaternion.identity, wordCanvas);
		/*	change collider name using a counter to differentiate tiles in raycast condition */
		Collider = GameObject.Find("Letter(Clone)/tiles/Collider");
		Collider.name = "collider " + count;
		count++;
		LetterDisplay letterDisplay = letterObj.GetComponent<LetterDisplay>();
		return letterDisplay;
	}

	public WordDisplay SpawnWord()
	{
		Vector3 position = new Vector3(0f, -6.75f);
		GameObject wordObj = Instantiate(wordPrefab, position, Quaternion.identity, wordCanvas);
		/*	change collider name using a counter to differentiate tiles in raycast condition */
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
		return wordDisplay;
	}
}
