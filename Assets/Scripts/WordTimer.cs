using UnityEngine;

public class WordTimer : MonoBehaviour
{
	public WordManager	wordManager;

	void Start()
	{
		wordManager.AddWord();
	}

	private	void Update()
	{
		GameObject [] Target = GameObject.FindGameObjectsWithTag("Word");
		foreach (GameObject item in Target)
		{
			float tilesPosition = item.transform.position.y;
			if (tilesPosition == 6.75f)
				wordManager.AddWord();
			if (tilesPosition <= -6.75f)
				Destroy(item);
		}
	}
}
