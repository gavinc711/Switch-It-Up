using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    public int score = 0;   //How many stars have you collected?

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
}
