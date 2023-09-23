using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public		GameObject wordPrefab;
	public		Transform wordCanvas;
	public		GameObject Collider;
	public int	count = 0;

	public WordDisplay SpawnWord()
	{
		float[]	tilesPosition = {-3f, -1f, 1f, 3f};
		int randomIndex = Random.Range(0, tilesPosition.Length);
		Vector3 randomPosition = new Vector3(tilesPosition[randomIndex], 9.5f);
		GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
		/*	change collider name using a counter to differentiate tiles in raycast condition */
		Collider = GameObject.Find("Word(Clone)/tiles/Collider");
		Collider.name = "collider " + count;
		count++;
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
		return wordDisplay;
	}
}
