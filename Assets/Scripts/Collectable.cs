using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableID;  // Unique ID for each collectable
    public int scoreValue = 10;   // Points for this collectable

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if this collectable has already been collected
            if (!Score.Instance.HasCollected(collectableID))
            {
                CollectItem();
            }
        }
    }

    void CollectItem()
    {
        // Add the collectable to the collected list
        Score.Instance.AddCollectedItem(collectableID);

        // Increase the player's score
        Score.Instance.AddScore(scoreValue);

        // Optionally destroy or deactivate the collectable
        Debug.Log("Collected: " + collectableID);
        Destroy(gameObject);
    }
}