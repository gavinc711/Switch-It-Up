using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseM : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public GameObject pauseCanvas;
    public GameObject mmCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;
    public GameObject controlsCanvas;


    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused)
            {
                Resume();

                if (mmCanvas.activeSelf)
                {
                    mmCanvas.SetActive(false);
                }

                if (creditsCanvas.activeSelf)
                {
                    creditsCanvas.SetActive(false);
                }

                if (settingsCanvas.activeSelf)
                {
                    settingsCanvas.SetActive(false);
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
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void BackToMain()
    {
        pauseCanvas.gameObject.SetActive(false);
        mmCanvas.gameObject.SetActive(true);
    }
}
