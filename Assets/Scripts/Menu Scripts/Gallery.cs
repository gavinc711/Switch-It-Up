using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void alien()
    {
        alienImage.gameObject.SetActive(true);
    }

    public void golf()
    {
        golfImage.gameObject.SetActive(true);
    }

    /* public void cs()
    {
        csImage.gameObject.SetActive(true);
    } */

    public void concept()
    {
        conceptImage.gameObject.SetActive(true);
    }

    public void purple()
    {
        purpleImage.gameObject.SetActive(true);
    }

    public void red()
    {
        redImage.gameObject.SetActive(true);
    }

    public void grey()
    {
        greyImage.gameObject.SetActive(true);
    }

    public void green()
    {
        greenImage.gameObject.SetActive(true);
    }

    public void blue()
    {
        blueImage.gameObject.SetActive(true);
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

    }
}
