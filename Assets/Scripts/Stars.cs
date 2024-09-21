using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
	private static bool collected = false;
	public static int starCount;
	
	void Start()
	{
		if (collected)
			this.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			this.gameObject.SetActive(false);
			collected = true;
			starCount += 1;
		}
	}
}
