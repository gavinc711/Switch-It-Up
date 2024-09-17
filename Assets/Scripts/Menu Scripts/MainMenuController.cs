using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;
    public GameObject controlsCanvas;
    public GameObject pauseCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_2_TunnelVision");
    }

    public void Settings()
    {
        settingsCanvas.gameObject.SetActive(true);
    }

    public void Credits()
    {
        creditsCanvas.gameObject.SetActive(true);
    }

    public void Controls()
    {
        controlsCanvas.gameObject.SetActive(true);
    }

    public void BackToSettings()
    {
        controlsCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMain()
    {
        if(pauseCanvas.activeSelf)
        {
            settingsCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(true);
        }
        else
        {
            settingsCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(false);
        }
    }
}