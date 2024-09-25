using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class UIOverhead : MonoBehaviour
{
    private Score ScoreScript;//Reference to the collectable script so that we drop stars on death
    public TextMeshProUGUI lvlNameTxt;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI winscoreTxt;

    void Start()
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
        int current = SceneManager.GetActiveScene().buildIndex;

        if(current == 2)
        {
            lvlNameTxt.text = "Level 1";
        }
        else if(current == 3)
        {
            lvlNameTxt.text = "Level 2";
        }
        else if(current == 4)
        {
            lvlNameTxt.text = "Level 3";
        }
        else if(current == 5)
        {
            lvlNameTxt.text = "Level 4";
        }
        else if(current == 6)
        {
            lvlNameTxt.text = "Level 5";
        }

        ScoreTxt.text = "Score: " + ScoreScript.score.ToString();
        winscoreTxt.text = ScoreScript.score.ToString();

    }

 

    
}
