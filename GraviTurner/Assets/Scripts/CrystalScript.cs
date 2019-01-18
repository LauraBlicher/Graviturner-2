using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour {

	public ParticleSystem shards, sparkles;
	private GameObject player;
	private AudioSource audioSource; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BreakCrystal()
	{
		shards.Play ();
		sparkles.Play ();
		GetComponent<Animator> ().SetBool ("isBreak", true);
		audioSource.Play (); 
	
	}

	public void CrystalBroke()
	{
		player.SendMessage("CrystalBroke");
	}
}
