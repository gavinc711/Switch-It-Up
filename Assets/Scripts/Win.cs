using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject youWin;
    public GameObject comet;
	public SpriteRenderer sprites;
	public Sprite newSprite;
	private Score ScoreScript;
    private Animator animator;
    private Animator cometAnimator;
    public AudioClip winSound;
    //private bool won = false;

    void Awake()
	{
        animator = GetComponent<Animator>();

        GameObject cometGameObject = GameObject.Find("Comet");
        GameObject foundGameObject = GameObject.Find("ScoreTracker");
        if (foundGameObject != null)
        {
            ScoreScript = foundGameObject.GetComponent<Score>();

            if (ScoreScript != null)
            {
                Debug.Log("Win got score script");
            }
            else
            {
                Debug.LogError("MyScript component not found on the found GameObject!");
            }
        }
        else
        {
            Debug.LogError("GameObject with the specified name not found!");
        }

        if (cometGameObject != null)
        {
            cometAnimator = cometGameObject.GetComponent<Animator>();

            if (ScoreScript != null)
            {
                Debug.Log("Win got score script");
            }
            else
            {
                Debug.LogError("MyScript component not found on the found GameObject!");
            }
        }
        else
        {
            Debug.LogError("GameObject with the specified name not found!");
        }

        comet.SetActive(false);
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
		{
            animator.SetBool("Won", true);
            comet.SetActive(true);
            cometAnimator.SetBool("Won", true);
            //won = true;
            ScoreScript.TransferPending();
			other.gameObject.SetActive(false);
			//sprites.sprite = newSprite;
            
            Music.instance.PlaySoundEffect(winSound);

        StartCoroutine(WaitForMenu(2f));
		}
    }
	
	private IEnumerator WaitForMenu(float delay)
	{
		yield return new WaitForSeconds(delay);
		youWin.SetActive(true);
	}
}
