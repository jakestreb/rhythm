using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public BeatManager beatManager;

    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown("space")) {
            beatManager.HitBeat();
        }
    }
}
