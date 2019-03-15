﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour {

    public float perfectHitMargin;
    public float goodHitMargin;
    public float hitMargin;
    public GameObject beat;
    public HitIndicator indicator;
    public Transform spawnPoint;
    public Transform beatTarget;

    private Queue<GameObject> beats = new Queue<GameObject>();

    public void HitBeat() {
        float songPos = ConductorController.songPosition;
        BeatMovement beatMovement = beats.Peek().GetComponent<BeatMovement>();
        float targetTime = beatMovement.GetTargetTime();
        if ((songPos > targetTime - hitMargin) && (songPos < targetTime + hitMargin)) {
            // Hit!
            Destroy(beats.Dequeue());
            bool goodHit = (songPos > targetTime - goodHitMargin) && (songPos < targetTime + goodHitMargin);
            bool perfectHit = goodHit && (songPos > targetTime - perfectHitMargin) && (songPos < targetTime + perfectHitMargin);
            StartCoroutine(indicator.Flash(perfectHit ? 3 : (goodHit ? 2 : 1)));
        }
    }

    public void SpawnBeat(int note, float spawnTime) {
        Debug.Log("SpawnBeat: " + note);
        if (note == 0) {
            return;
        }
        GameObject newBeat = Instantiate(beat, spawnPoint.position, spawnPoint.rotation);
        BeatMovement newBeatMovement = newBeat.GetComponent<BeatMovement>();
        newBeatMovement.SetSpawnTime(spawnTime);
        beats.Enqueue(newBeat);
    }

    // Update is called once per frame
    void Update () {
        DequeueMissedBeats();
    }

    void DequeueMissedBeats() {
        if (beats.Count == 0) {
            return;
        }
        BeatMovement beatMovement = beats.Peek().GetComponent<BeatMovement>();
        while (ConductorController.songPosition > beatMovement.GetTargetTime() + hitMargin) {
            beats.Dequeue();
            StartCoroutine(indicator.Flash(0));
            if (beats.Count == 0) {
                return;
            }
            beatMovement = beats.Peek().GetComponent<BeatMovement>();
        }
    }

}