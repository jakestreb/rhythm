using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public BeatManager beatManager;
    public string keyName;

    // Use this for initialization
    void Start () {

	}

	void Update () {
        if (Input.GetKeyDown(keyName)) {
            beatManager.HitBeat();
        }
    }
}
