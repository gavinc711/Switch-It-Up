using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class MainMenuController : MonoBehaviour
{
    public GameObject settings;
    public GameObject credits;
    public GameObject controls;
    public GameObject lvls;

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");  //Was loading the wrong scene, so I made it load tutorial instead (did it by name, sorry!)
    }
    public void PlayGame2()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the valid range of scenes in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes in the build order.");
        }
    }

    public void Settings()
    {
        settings.gameObject.SetActive(true);
    }

    public void Credits()
    {
        credits.gameObject.SetActive(true);
    }

    public void Controls()
    {
        controls.gameObject.SetActive(true);
    }

    public void BackToSettings()
    {
        controls.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
    }
	
	public void BackToMain()
    {
        if (settings.activeSelf)
			settings.gameObject.SetActive(false);
		if (credits.activeSelf)
			credits.gameObject.SetActive(false);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenLvlSelect()
    {
        lvls.gameObject.SetActive(true);
    }
	
	public void Tutorial() 
    {
        SceneManager.LoadScene(1);
    }
	
	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}