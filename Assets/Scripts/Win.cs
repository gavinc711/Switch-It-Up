using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject youWin;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.GetComponent<PlayerScript>();
        
        if(player != null)
        {
            youWin.SetActive(true);
        }
        else
        {
            youWin.SetActive(false);
        }
    }

}
