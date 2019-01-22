using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCrystalScript : MonoBehaviour {

    public bool hasHammer;
	private GameObject npc;

    public UnityEngine.UI.Button winButton;
    public UnityEngine.UI.Text winText;
    public UnityEngine.UI.Image buttonImage;
	private bool hasWon;
	public float winDelay = 1.5f;
    private AudioSource aSource;
    public AudioClip hammerSound;

	void Start()
	{
		npc = GameObject.FindGameObjectWithTag ("NPC");
        aSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Crystal")
        {
			if (!hasWon) {
				if (hasHammer) {
					other.SendMessage ("BreakCrystal");

					hasWon = true;
				}
			}
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hammer")
        {
            hasHammer = true;
            aSource.PlayOneShot(hammerSound);
            Destroy(other.gameObject);
        }
    }

	public void CrystalBroke()
	{
		npc.GetComponent<Animator> ().SetBool ("isFree", true);
		StartCoroutine (WinScreen ());
	}

	IEnumerator WinScreen() 
	{
		yield return new WaitForSeconds (winDelay);
		winButton.enabled = true;
		winText.enabled = true;
		buttonImage.enabled = true;
	}
}
