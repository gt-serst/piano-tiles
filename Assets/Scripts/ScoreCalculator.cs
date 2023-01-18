using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
	public TMP_Text score;
	public TMP_Text finalScore;
	public TMP_Text accuracy;
	public WordManager wordManager;

	void Update()
	{
		score.text = "" + (wordManager.correctLetters);
		finalScore.text = (wordManager.correctLetters) + " lettres corrects";
		accuracy.text = (int)((1 - (wordManager.incorrectLetters / wordManager.correctLetters))*100)+"%";
	}
}
