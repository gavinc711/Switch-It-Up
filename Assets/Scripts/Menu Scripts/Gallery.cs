using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gallery : MonoBehaviour
{
    // charcter
    public GameObject partyImage;
    public GameObject alienImage;
    public GameObject golfImage;
   // public GameObject csImage;
    public GameObject conceptImage;

    //backgrounds
    public GameObject purpleImage;
    public GameObject redImage;
    public GameObject greyImage;
    public GameObject greenImage;
    public GameObject blueImage;
    public Score ScoreScript;
	
	//EventSystem button settings to make UI work for controller
	public GameObject partyFirst;
    public GameObject conceptFirst;
    public GameObject alienFirst;
    public GameObject golfFirst;
    public GameObject purpleFirst;
    public GameObject redFirst;
    public GameObject greyFirst;
    public GameObject greenFirst;
    public GameObject blueFirst;
	public GameObject galleryFirst;

    void Awake()
    {
        GameObject targetObject = GameObject.Find("ScoreTracker");
        if (targetObject != null)
        {
            ScoreScript = targetObject.GetComponent<Score>();
        }
        if (ScoreScript != null)
        {
            Debug.Log("Player found score script.");
        }
        else
        {
            Debug.LogError("script reference is not found on the target gameobject!");
        }
    }
    public void party()
    {
        partyImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(partyFirst);
    }

    public void alien()
    {
        alienImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(alienFirst);
    }

    public void golf()
    {
        golfImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(golfFirst);
    }

    /* public void cs()
    {
        csImage.gameObject.SetActive(true);
    } */

    public void concept()
    {
        conceptImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(conceptFirst);
    }

    public void purple()
    {
        purpleImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(purpleFirst);
    }

    public void red()
    {
        redImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(redFirst);
    }

    public void grey()
    {
        greyImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(greyFirst);
    }

    public void green()
    {
        greenImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(greenFirst);
    }

    public void blue()
    {
        blueImage.gameObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(blueFirst);
    }

    public void Back()
    {
        // character
        partyImage.gameObject.SetActive(false);
        alienImage.gameObject.SetActive(false);
        golfImage.gameObject.SetActive(false);
     //   csImage.gameObject.SetActive(false);
        conceptImage.gameObject.SetActive(false);

        // backgrounds
        purpleImage.gameObject.SetActive(false);
        redImage.gameObject.SetActive(false);
        greyImage.gameObject.SetActive(false);
        greenImage.gameObject.SetActive(false);
        blueImage.gameObject.SetActive(false);
		
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(galleryFirst);
    }
}
