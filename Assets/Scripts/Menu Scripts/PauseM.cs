using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseM : MonoBehaviour
{
    public GameObject pause;
    public bool GameIsPaused = false;

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
