using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class UIOverhead : MonoBehaviour
{
    public Score stars;//Reference to the collectable script so that we drop stars on death
    public TextMeshProUGUI lvlNameTxt;
    public TextMeshProUGUI ScoreTxt;

    void Start()
    {
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

        stars.AddScore(stars.score);
        ScoreTxt.text = "Score: " + stars.score.ToString();
    }

 

    
}
