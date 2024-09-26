using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LVLSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public void Tutorial() 
    {
		Destroy(EventSystem.current);
        SceneManager.LoadScene(1);
        Music.instance.SwitchMusic(2);
    }
    public void Lvl1() 
    {
		Destroy(EventSystem.current);
        SceneManager.LoadScene(2);
        Music.instance.SwitchMusic(1);
    }
    public void Lvl2() 
    {
		Destroy(EventSystem.current);
        SceneManager.LoadScene(3);
        Music.instance.SwitchMusic(2);
    }
    public void Lvl3() 
    {
		Destroy(EventSystem.current);
        SceneManager.LoadScene(4);
        Music.instance.SwitchMusic(1);
    }
    public void Lvl4() 
    {
		Destroy(EventSystem.current);
        SceneManager.LoadScene(5);
        Music.instance.SwitchMusic(2);
    }
    public void Lvl5() 
    {
		Destroy(EventSystem.current);
        SceneManager.LoadScene(6);
        Music.instance.SwitchMusic(1);
    }
}
