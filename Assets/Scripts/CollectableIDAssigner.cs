using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectableIDAssigner : MonoBehaviour
{
    public string levelName; // Manually assign the level name here (e.g., "Level1", "Level2")

    private void Start()
    {
        AssignCollectableIDs();
    }

    void AssignCollectableIDs()
    {
        Collectable[] collectables = FindObjectsOfType<Collectable>();
        collectables = collectables.OrderBy(collectable => collectable.gameObject.name).ToArray();

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].collectableID = levelName + "_Star" + (i + 1);
            Debug.Log("Assigned ID: " + collectables[i].collectableID + ", i = " + i);
            
        }
    }
}