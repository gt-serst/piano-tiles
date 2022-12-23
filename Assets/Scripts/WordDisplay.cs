using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
	public TMP_Text letter;

	public void SetWord(string word)
	{
		letter.text = word;
	}

	public void	RemoveLetter()
	{
		letter.text = letter.text.Remove(0, 1);
		letter.color = Color.green;
	}
	public void RemoveWord()
	{
		Destroy(gameObject);
	}

	public void Update()
	{
		transform.Translate(0f, (Time.deltaTime * (-2f)), 0f);
	}
}
