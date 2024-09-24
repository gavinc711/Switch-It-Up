using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class MainMenuController : MonoBehaviour
{
    public GameObject settings;
    public GameObject extras;
    public GameObject controls;
    public GameObject credits;
    public GameObject gallery;
    public GameObject lvls;

    public int currentSceneIndex;
    public int nextSceneIndex;

    
    public void PlayGame2()
    {
        // Get the current scene index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        nextSceneIndex = currentSceneIndex + 1;

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

    public void Extras()
    {
        extras.gameObject.SetActive(true);
    }

    public void Gallery()
    {
        gallery.gameObject.SetActive(true);
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

    public void BackToExtras()
    {
        gallery.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        extras.gameObject.SetActive(true);
    }
	
	public void BackToMain()
    {
        if (settings.activeSelf)
			settings.gameObject.SetActive(false);
        if (extras.activeSelf)
			extras.gameObject.SetActive(false);
		 if (lvls.activeSelf)
			lvls.gameObject.SetActive(false);
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