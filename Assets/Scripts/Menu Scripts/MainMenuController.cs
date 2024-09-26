using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
	public GameObject mainMenu;
    public GameObject settings;
    public GameObject extras;
    public GameObject controls;
    public GameObject credits;
    public GameObject gallery;
    public GameObject lvls;
    public Score ScoreScript;

    public GameObject partyImage;
    public GameObject alienImage;
    public GameObject golfImage;
    // public GameObject csImage;
    public GameObject conceptImage;


    public GameObject unlock;
    //backgrounds
    public GameObject purpleImage;
    public GameObject redImage;
    public GameObject grayImage;
    public GameObject greenImage;
    public GameObject blueImage;

    public GameObject partyLock;
    public GameObject conceptLock;
    public GameObject alienLock;
    public GameObject golfLock;
    public GameObject purpleLock;
    public GameObject redLock;
    public GameObject grayLock;
    public GameObject greenLock;
    public GameObject blueLock;
	
	//EventSystem button settings to make UI work for controller
	public GameObject mainMenuFirst;
	public GameObject settingsFirst;
	public GameObject controlsFirst;
	public GameObject creditsFirst;
	public GameObject lvlFirst;
	public GameObject galleryFirst;
	public GameObject extrasFirst;

    public int currentSceneIndex;
    public int nextSceneIndex;
    private int m = 0;
	
    public void PlayGame2()
    {
        // Get the current scene index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        nextSceneIndex = currentSceneIndex + 1;
        //This shit swaps music tracks between levels
        if (nextSceneIndex == 1)
            m = nextSceneIndex;
        else
            m = (nextSceneIndex % 2) + 1;
        Debug.Log("m = " + m + "CSI = " + nextSceneIndex);
        Music.instance.SwitchMusic(m);


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
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(settingsFirst);
    }

    public void Extras()
    {
        extras.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(extrasFirst);
    }

    public void Gallery()
    {
		mainMenu.gameObject.SetActive(false);
		extras.gameObject.SetActive(false);
        gallery.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(galleryFirst);
		
        GameObject targetObject = GameObject.Find("ScoreTracker");
        if (targetObject != null)
        {
            ScoreScript = targetObject.GetComponent<Score>();
        }
        if (ScoreScript != null)
        {
            //Debug.Log("Player found score script.");
        }
        else
        {
            Debug.LogError("script reference is not found on the target gameobject!");
        }

        if(ScoreScript.score >= 2)
        {
            unlock.SetActive(true);
            partyLock.SetActive(false);
            partyImage.SetActive(true);
        }
        if (ScoreScript.score >= 4)
        {
            conceptLock.SetActive(false);
            conceptImage.SetActive(true);
        }
        if (ScoreScript.score >= 6)
        {
            alienLock.SetActive(false);
            alienImage.SetActive(true);
        }
        if (ScoreScript.score >= 8)
        {
            golfLock.SetActive(false);
            golfImage.SetActive(true);
        }
        if (ScoreScript.score >= 10)
        {
            purpleLock.SetActive(false);
            purpleImage.SetActive(true);
        }
        if (ScoreScript.score >= 12)
        {
            redLock.SetActive(false);
            redImage.SetActive(true);
        }
        if (ScoreScript.score >= 14)
        {
            grayLock.SetActive(false);
            grayImage.SetActive(true);
        }
        if (ScoreScript.score >= 16)
        {
            greenLock.SetActive(false);
            greenImage.SetActive(true);
        }
        if(ScoreScript.score >= 18)
        {
            blueLock.SetActive(false);
            blueImage.SetActive(true);
        }
    }

    public void Credits()
    {
        credits.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(creditsFirst);
    }

    public void Controls()
    {
        controls.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(controlsFirst);
    }

    public void BackToSettings()
    {
        controls.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(settingsFirst);
    }

    public void BackToExtras()
    {
        gallery.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(true);
        extras.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(extrasFirst);
    }
	
	public void BackToMain()
    {
        if (settings.activeSelf)
			settings.gameObject.SetActive(false);
        if (extras.activeSelf)
			extras.gameObject.SetActive(false);
		if (lvls.activeSelf)
			lvls.gameObject.SetActive(false);
		
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(mainMenuFirst);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenLvlSelect()
    {
        lvls.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(lvlFirst);
    }
	
	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
        Music.instance.SwitchMusic(0);
    }
}