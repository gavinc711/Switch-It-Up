using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseM : MonoBehaviour
{
    public GameObject pause;
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public GameObject controls;
    private PlayerInput input;

    public static bool GameIsPaused = false;

    void Start()
    {
        input = new PlayerInput(); //initializes input
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Menu.Select.triggered)
        {
            if (GameIsPaused)
            {
                Resume();

                if (settings.activeSelf)
                {
                    settings.SetActive(false);
                }
            } 
            else
            {
                Paused();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
