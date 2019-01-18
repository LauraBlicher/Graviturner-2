using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerScript1 : MonoBehaviour {

    public static GameObject player, player2;
    public GameObject newPlayer, newPlayer2;
    public Transform respawn, respawn2;
    private bool readyToRespawn;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2"); //this
        respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        respawn2 = GameObject.FindGameObjectWithTag("Respawn2").transform; //this
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.isDead)
        {
            StartCoroutine(PlayerDeath());
        }

        if (readyToRespawn)
        {
            if (Input.GetButtonDown("Respawn"))
            {
              player = Instantiate(newPlayer, respawn.position, respawn.rotation);
              readyToRespawn = false;
            } //this
            if (Input.GetButtonDown("Respawn"))
            {
                player2 = Instantiate(newPlayer, respawn.position, respawn.rotation);
                readyToRespawn = false;
            }
        } //till this
	}
    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(1f);
        PlayerController.isDead = false;
        Destroy(player);
        Destroy(player2);
        readyToRespawn = true;

    }
}
