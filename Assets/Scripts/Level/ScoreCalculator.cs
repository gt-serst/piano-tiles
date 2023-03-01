using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
	public				TMP_Text score;
	public				TMP_Text finalScore;
	public				TMP_Text accuracy;
	public float		accuracyInPercent;
	public WordManager	wordManager;

	void Update()
	{
		score.text = "" + (wordManager.correctLetters);
		finalScore.text = (wordManager.correctLetters) + " lettres correctes";
		accuracyInPercent = (1 - (wordManager.incorrectLetters / wordManager.correctLetters)) * 100;
		if (System.Single.IsNaN(accuracyInPercent))
			accuracy.text = "Tu n'as pas tapé de touches";
		else if (accuracyInPercent < 0)
			accuracy.text = "Tu as fait quelques fautes, ce n'est pas grave, tu apprends de tes erreurs !";
		else
			accuracy.text = (int)accuracyInPercent+" %, bravo !";
	}
}
