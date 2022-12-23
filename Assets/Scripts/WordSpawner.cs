using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public GameObject wordPrefab;
	public Transform wordCanvas;

	public WordDisplay SpawnWord()
	{
		float[]	tilesPosition = {-3f, -1f, 1f, 3f};
		int randomIndex = Random.Range(0, tilesPosition.Length);

		Vector3 randomPosition = new Vector3(tilesPosition[randomIndex], 9.5f);
		GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
		return wordDisplay;
	}
}
