using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableIDAssigner : MonoBehaviour
{
    private void Start()
    {
        Collectable[] collectables = FindObjectsOfType<Collectable>();

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].collectableID = "collectable_" + i;
        }
    }
}