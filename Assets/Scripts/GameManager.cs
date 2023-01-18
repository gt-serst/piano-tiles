using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public AudioSource audioSource;
	public  AudioClip audioClip;
	public GameObject scoreMenuUI;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
	}

	void Update()
	{
		if(audioSource.clip.length - Time.timeSinceLevelLoad < 0f)
		{
			Time.timeScale = 0f;
			scoreMenuUI.SetActive(true);
		}
	}
}
