using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class GameManager : MonoBehaviour
{
	// start react unity web gl
	[DllImport("__Internal")]
	private static extern void GameFinished (string text, string text_typed, int duration);
	// end react unity web gl
	public AudioManager audioManager;
	public GameObject scoreMenuUI;
	public WordManager wordManager;// used to send informations to reactJS to store the restults in DB when the game is finished
	public int level;

	public void Awake()
	{
		level = PlayerPrefs.GetInt("Sauv_Language");
	}
	void Update()
	{
		if(level == 1 && (audioManager.audioSource.clip.length/2 - Time.timeSinceLevelLoad) < 0f)
		{
			string text = wordManager.GetText();
			string text_typed = wordManager.GetTextTyped();
			int duration = wordManager.GetDuration();
			// the game is finished
			#if UNITY_WEBGL == true && UNITY_EDITOR == false
			GameFinished(text, text_typed, duration);
			#endif
			Time.timeScale = 0f;
			audioManager.StopPlaying();
			scoreMenuUI.SetActive(true);
		}
		if (level == 2 && audioManager.audioSource.clip.length - Time.timeSinceLevelLoad < 0f)
		{
			string text = wordManager.GetText();
			string text_typed = wordManager.GetTextTyped();
			int duration = wordManager.GetDuration();
			// the game is finished
			#if UNITY_WEBGL == true && UNITY_EDITOR == false
			GameFinished(text, text_typed, duration);
			#endif
			Time.timeScale = 0f;
			scoreMenuUI.SetActive(true);
		}
	}
}
