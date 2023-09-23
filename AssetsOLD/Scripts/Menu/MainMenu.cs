using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int level;
    
    public void Start()
    {
    	Time.timeScale = 1f;
    }
    public void PlayLevelOne()
    {
    	level = 1;
    	SceneManager.LoadScene("Level");
    	PlayerPrefs.SetInt("Sauv_Language", level);
    }
    public void PlayLevelTwo()
    {
    	level = 2;
    	SceneManager.LoadScene("Level");
    	PlayerPrefs.SetInt("Sauv_Language", level);
    }
}
