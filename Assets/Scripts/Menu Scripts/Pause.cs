using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Pause : MonoBehaviour
{
    public PlayerInput input;
    public PlayerScript playerScript;

    void Awake()
    {
        input = new PlayerInput();
    }

    void Update()
    {
        
    }

    public void Resume(PlayerScript playerScript)
    {
        playerScript.gamePause();
    }
}
