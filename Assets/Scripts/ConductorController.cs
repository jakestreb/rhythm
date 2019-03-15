using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorController : MonoBehaviour {

    public static float songPosition = 0.0f;
    public int measureCounter;
    public int beatCounter;
    public float measureDuration;
    public float beatDuration;
    public GameObject song;
    public BeatManager beatManager;

    private float nextMeasureStartTime = 0.0f;
    private float nextBeatStartTime = 0.0f;
    private double startDspTime;
    private AudioSource music;
    private SongMetadata metadata;

    void Awake() {
        music = song.GetComponent<AudioSource>();
        metadata = song.GetComponent<SongMetadata>();
        measureCounter = -1;
        beatCounter = -1;
    }

    // Use this for initialization
    void Start() {
        measureDuration = (4 * 60) / metadata.bpm;
        PlaySong();
    }

    // Update is called once per frame
    void Update() {
        songPosition = (float)(AudioSettings.dspTime - startDspTime)
            * music.pitch - metadata.offset;
        Debug.Log("songPosition: " + songPosition);
        if (songPosition >= nextMeasureStartTime) {
            measureCounter += 1;
            beatCounter = 0;
            Debug.Log("measureCounter: " + measureCounter);
            Debug.Log("beatCounter: " + beatCounter);
            beatManager.SpawnBeat(metadata.notes[measureCounter][beatCounter], nextMeasureStartTime);
            beatDuration = measureDuration / metadata.notes[measureCounter].Length;
            nextMeasureStartTime += measureDuration;
            nextBeatStartTime += beatDuration;
        }
        else if (songPosition >= nextBeatStartTime) {
            beatCounter += 1;
            Debug.Log("beatCounter: " + beatCounter);
            beatManager.SpawnBeat(metadata.notes[measureCounter][beatCounter], nextBeatStartTime);
            nextBeatStartTime += beatDuration;
        }
    }

    void PlaySong() {
        startDspTime = AudioSettings.dspTime;
        Debug.Log("startDspTime: " + startDspTime);
        music.PlayDelayed(BeatManager.beatSpawnOffsetTime);
    }
}
