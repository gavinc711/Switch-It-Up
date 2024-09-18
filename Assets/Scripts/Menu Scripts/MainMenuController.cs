using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject settings;
    public GameObject credits;
    public GameObject controls;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_2_TunnelVision");
    }

    public void Settings()
    {
        settings.gameObject.SetActive(true);
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

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}