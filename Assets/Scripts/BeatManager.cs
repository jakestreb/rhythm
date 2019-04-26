using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour {

    public static float beatSpeed = 5.0f;
    public static float beatSpawnOffsetTime;
    public float spawnDelay = 0.0f;
    public float perfectHitMargin;
    public float goodHitMargin;
    public float hitMargin;
    public GameObject beat;
    public HitIndicator indicator;
    public Transform spawnPoint;
    public Transform beatTarget;

    private Queue<GameObject> beats = new Queue<GameObject>();

    public void HitBeat() {
        if (beats.Count == 0) {
            return;
        }
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

    public void SpawnBeat(float spawnTime) {
        GameObject newBeat = Instantiate(beat, spawnPoint.position, spawnPoint.rotation);
        BeatMovement newBeatMovement = newBeat.GetComponent<BeatMovement>();
        newBeatMovement.Initialize(spawnPoint, spawnTime + spawnDelay, beatSpawnOffsetTime - spawnDelay);
        beats.Enqueue(newBeat);
    }

    private void Awake() {
        // Pre-calculate beatSpawnOffsetTime using the beatSpeed to avoid calculating for each beat
        float dist = spawnPoint.position.y - beatTarget.position.y;
        beatSpawnOffsetTime = dist / beatSpeed;
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
