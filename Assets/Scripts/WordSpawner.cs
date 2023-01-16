using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public GameObject wordPrefab;
	public Transform wordCanvas;
	private static int compteur = 0;
	public GameObject tilesImage;

	public WordDisplay SpawnWord()
	{
		float[]	tilesPosition = {-3f, -1f, 1f, 3f};
		int randomIndex = Random.Range(0, tilesPosition.Length);
		Vector3 randomPosition = new Vector3(tilesPosition[randomIndex], 9.5f);
		GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
		/*	change gameobject name using a counter to differentiate prefabs in raycast condition check */
		tilesImage = GameObject.Find("Word(Clone)/tiles");
		tilesImage.name = "tiles" + compteur;
		compteur++;
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
		return wordDisplay;
	}
}
