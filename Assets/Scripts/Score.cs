using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    public int score = 0;   //How many stars have you collected?
    public string temp1 = "empty";
    public string temp2 = "empty";
    public string temp3 = "empty";
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    // HashSet to store collected items' IDs
    private HashSet<string> collectedItems = new HashSet<string>();

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this manager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
         temp1 = "empty";
         temp2 = "empty";
         temp3 = "empty";
        GameObject Star1 = GameObject.Find("Star 1");
        GameObject Star2 = GameObject.Find("Star 2");
        GameObject Star3 = GameObject.Find("Star 3");
        Debug.Log("Found the object: " + Star2.name);
    }

    // Method to check if a collectable has been collected
    public bool HasCollected(string id)
    {
        return collectedItems.Contains(id);
    }

    // Method to add a collectable to the collected list
    public void AddCollectedItem(string id)
    {
        collectedItems.Add(id);
    }

    // Method to increase the score
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    public void PendingCollect(string id)
    {

        Debug.Log("Collected " + id + ", storing the data for goal");
        Debug.Log("Pending Collect says: temp1 = " + temp1);
        Debug.Log("Pending Collect says: temp2 = " + temp2);
        Debug.Log("Pending Collect says: temp3 = " + temp3);
        if (temp1 == "empty")
        {
            temp1 = id;
            Debug.Log("Pending Collect says: temp1 = " + temp1);
        }
        else if (temp2 == "empty")
        {
            temp2 = id;
            Debug.Log("Pending Collect says: temp2 = " + temp2);
        }
        else
        {
            temp3 = id;
            Debug.Log("Pending Collect says: temp3 = " + temp3);
        }
    }
    public void ActivateResetStars()
    {
        ResetStars();
    }
    public void ResetStars()
    {
        //Debug.Log("this worked 1, temp1 = " + temp1);
        //Debug.Log("Found the object: " + Star1.name);
        Star1.SetActive(true);
        temp1 = "empty";

        //Debug.Log("this worked 2, temp2 = " + temp2);
        //Debug.Log("Found the object: " + Star2.name);
        Star2.SetActive(true);
        temp2 = "empty";

       // Debug.Log("this worked 3, temp3 = " + temp3);
        Star3.SetActive(true);
        temp3 = "empty";
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
        Score.Instance.AddScore(1);

        // Optionally destroy or deactivate the collectable
        Debug.Log("Collected: " + tempID);

    }
}
