using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public GameObject playerPrefab;
    public float playerHeight = -0.25f;
    public float playerDistanceToCam = 2.0f;
	// Use this for initialization
	void Start ()
    {
        var player = Instantiate(playerPrefab);
        player.transform.Translate(0, playerDistanceToCam, playerHeight);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
