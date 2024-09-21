using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject youWin;
	public SpriteRenderer sprites;
	public Sprite newSprite;
    
	void Awake()
	{
		sprites = GetComponent<SpriteRenderer>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
		{
			other.gameObject.SetActive(false);
			sprites.sprite = newSprite;
			StartCoroutine(WaitForMenu(2f));
		}
    }
	
	private IEnumerator WaitForMenu(float delay)
	{
		yield return new WaitForSeconds(delay);
		youWin.SetActive(true);
	}
}
