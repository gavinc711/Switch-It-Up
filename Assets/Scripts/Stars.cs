using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
	public string id;
	public static int starCount;
	
	void Awake()
	{
		if(PlayerPrefs.GetInt(id, 0) == 1)
			this.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			this.gameObject.SetActive(false);
			PlayerPrefs.SetInt(id, 1);
			starCount += 1;
		}
	}
}
