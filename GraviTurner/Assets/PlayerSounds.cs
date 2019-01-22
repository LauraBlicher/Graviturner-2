using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

    private AudioSource aSource;
    public AudioClip step;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LeftStep()
    {
        aSource.pitch = 1f;
        aSource.PlayOneShot(step);
    }

    public void RightStep()
    {
        aSource.pitch = 1.5f;
        aSource.PlayOneShot(step);
    }
}
