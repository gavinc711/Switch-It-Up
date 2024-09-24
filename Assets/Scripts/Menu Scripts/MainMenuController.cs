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