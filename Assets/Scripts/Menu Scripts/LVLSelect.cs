using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLSelect : MonoBehaviour
{
    // Start is called before the first frame update
   public void Lvl1() 
    {
        SceneManager.LoadScene(2);
    }
    public void Lvl2() 
    {
        SceneManager.LoadScene(3);
    }
    public void Lvl3() 
    {
        SceneManager.LoadScene(4);
    }
    public void Lvl4() 
    {
        SceneManager.LoadScene(5);
    }
    public void Lvl5() 
    {
        SceneManager.LoadScene(6);
    }
}
