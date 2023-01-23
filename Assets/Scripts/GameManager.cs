using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class GameManager : MonoBehaviour
{
	// start react unity web gl
	[DllImport("__Internal")]
	private static extern void GameFinished (string text, string text_typed, int duration);
	// end react unity web gl
	public AudioSource audioSource;
	public  AudioClip audioClip;
	public GameObject scoreMenuUI;
	public WordManager wordManager;// used to send informations to reactJS to store the restults in DB when the game is finished

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
	}

	void Update()
	{
		if(audioSource.clip.length - Time.timeSinceLevelLoad < 0f)
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
