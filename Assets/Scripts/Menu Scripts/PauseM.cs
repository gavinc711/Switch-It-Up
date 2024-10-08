using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class PauseM : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject settings;
    public GameObject pause;
    public GameObject controls;
	public GameObject overhead;
    public AudioClip pauseSound;


    private void Start()
    {
        Resume();
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
		overhead.SetActive(true);
		
		if (settings.activeSelf)
            settings.SetActive(false);
        if (controls.activeSelf)
            controls.SetActive(false);
    }


    public void Paused()
    {
        Music.instance.PlaySoundEffect(pauseSound);
        pause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        overhead.SetActive(false);
    }

    public void BackToPause()
    {
        settings.SetActive(false);
        pause.SetActive(true);
    }
}
