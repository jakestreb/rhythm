﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMovement : MonoBehaviour {

    public static float beatSpeed = 5.0f;
    public static float beatDist;
    public static float beatSpawnOffsetTime;
    public float spawnY;
    public float targetY;
    public float destroyY;

    private Rigidbody2D beatRigidBody;
    private float spawnTime; // The conductor songPosition value at spawn time
    private float targetTime; // The conductor songPosition beat time

    public void SetSpawnTime(float _spawnTime) {
        spawnTime = _spawnTime;
        targetTime = _spawnTime + beatSpawnOffsetTime;
    }

    public float GetTargetTime() {
        return targetTime;
    }

    void Awake() {
        beatRigidBody = GetComponent<Rigidbody2D>();
        beatDist = spawnY - targetY;
        beatSpawnOffsetTime = beatDist / beatSpeed;
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
            ((ConductorController.songPosition - spawnTime) / beatSpawnOffsetTime);
        beatRigidBody.MovePosition((Vector2.up * spawnY) + movement);
    }

    void DestroyIfOffscreen() {
        if (transform.position.y < destroyY) {
            Destroy(gameObject);
        }
    }

}
