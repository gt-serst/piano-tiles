using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
	public TMP_Text letter;

	public void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
		ReactWebController rwc = objs[0].GetComponent<ReactWebController>();
		if (rwc.userFont && rwc.userFontSize != 0)
		{
			letter.font = rwc.userFont;
			letter.fontSize = rwc.userFontSize;
		}
	}
	public void SetWord(string word)
	{
		letter.text = word;
	}
	public void ChangeLettersColor()
	{
		letter.color = Color.red;
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
		transform.Translate(0f, (Time.deltaTime * (-1.75f)), 0f);
	}
}
