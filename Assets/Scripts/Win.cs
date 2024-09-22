using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject youWin;
	public SpriteRenderer sprites;
	public Sprite newSprite;
	private Score ScoreScript;

	void Awake()
	{
		sprites = GetComponent<SpriteRenderer>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
		{
			ScoreScript.TransferPending();
			other.gameObject.SetActive(false);
			sprites.sprite = newSprite;
			StartCoroutine(WaitForMenu(2f));
		}
    }
	
	private IEnumerator WaitForMenu(float delay)
	{
		yield return new WaitForSeconds(delay);
		youWin.SetActive(true);
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(0);
	}
}
