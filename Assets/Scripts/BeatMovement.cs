﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMovement : MonoBehaviour {

    public float beatDist;
    public float speed;
    public float spawnY;
    public float targetY;
    public float destroyY;

    private Rigidbody2D beatRigidBody;
    private float spawnTime; // The conductor songPosition value at spawn time
    private float targetTime; // The conductor songPosition beat time
    private float spawnOffsetTime;

    public void Initialize(float _spawnTime, float _offset) {
        Debug.Log("Initialize: " + _spawnTime + " " + _offset);
        spawnOffsetTime = _offset;
        spawnTime = _spawnTime;
        targetTime = _spawnTime + spawnOffsetTime;
    }

    public float GetTargetTime() {
        return targetTime;
    }

    void Awake() {
        beatRigidBody = GetComponent<Rigidbody2D>();
        beatDist = spawnY - targetY;
    }

    // Use this for initialization
    void Start() {
		
	}

	// Update is called once per frame
	void FixedUpdate() {
        Move();
        DestroyIfOffscreen();
    }

    void Move() {
        Vector2 movement = Vector2.down * beatDist *
            ((ConductorController.songPosition - spawnTime) / spawnOffsetTime);
        beatRigidBody.MovePosition((Vector2.up * spawnY) + movement);
    }

    void DestroyIfOffscreen() {
        if (transform.position.y < destroyY) {
            Destroy(gameObject);
        }
    }
}
