using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneEvents : MonoBehaviour {

    public AudioSource aSource;
    public AudioClip roar;
    public GameObject crystal, fade;
    private Animator anim;
    private Image fadeImg;
    private bool fading;


	// Use this for initialization
	void Start () {
        anim = crystal.GetComponent<Animator>();
        fadeImg = fade.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 4.57f)
        {
            aSource.PlayOneShot(roar, 0.08f);
        }
        if (transform.position.x > 117.74f)
        {
            anim.SetBool("crystalGrow", true);
        }

        if (!fading)
        {
            if (transform.position.x > 125f)
            {
                StartCoroutine(Fade());
            }
        }
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        fading = true;
        for(float f = 0f; f < 1f; f = f + 0.05f)
        {
            fadeImg.color = new Color(0, 0, 0, f);
            yield return new WaitForSeconds(0.1f);
        }

        if (fadeImg.color.a > 0.94f)
        {
            SceneManager.LoadScene("New0.0");
        }
    }
}
