using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableID;  // Unique ID for each collectable
    //public string temp1;
    //public string temp2;
    //public string temp3;
    private Score ScoreScript;
    //private List<GameObject> activeCollectables = new List<GameObject>();
    public AudioClip starSound;
    void Start()
    {
        // Find the GameObject by name and get the script component
        GameObject targetObject = GameObject.Find("ScoreTracker"); // Replace with the actual GameObject name
        if (targetObject != null)
        {
            ScoreScript = targetObject.GetComponent<Score>();
        }

        // Check if the script reference is assigned
        if (ScoreScript != null)
        {
            Debug.Log("Collectable found score script");
        }
        else
        {
            Debug.LogError("Script reference is not found on the target GameObject!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if this collectable has already been collected
            if (!Score.Instance.HasCollected(collectableID))
            {
                gameObject.SetActive(false);
                ScoreScript.PendingCollect(collectableID);
                Music.instance.PlaySoundEffect(starSound);
            }
        }
    }

    /*
    void PendingCollect(string id)
    {
        
        Debug.Log("Collected " + id + ", storing the data for goal");
        if(temp1 == null)
        {
            temp1 = id;
        }
        else if(temp2 == null)
        {
            temp2 = id;
        }
        else
        {
            temp3 = id;
        }
    }
    public void ResetStars()
    {
        Debug.Log("this worked 1");
        GameObject.Find("Star 1").SetActive(true);
        temp1 = null;

        Debug.Log("this worked 2");
        GameObject.Find("Star 2").SetActive(true);
        temp2 = null;

        Debug.Log("this worked 3");
        GameObject.Find("Star 3").SetActive(true);       
        temp3 = null;
    }
    
    public void TransferPending()
    {
        if (temp1 != null)
        {
            CollectItem(temp1);
        }
        if (temp2 != null)
        {
            CollectItem(temp2);
        }
        if (temp3 != null)
        {
            CollectItem(temp3);
        }
    }

    private void CollectItem(string tempID)
    {
        // Add the collectable to the collected list
        Score.Instance.AddCollectedItem(tempID);

        // Increase the player's score
        Score.Instance.AddScore(scoreValue);

        // Optionally destroy or deactivate the collectable
        Debug.Log("Collected: " + tempID);
        
    }*/
}