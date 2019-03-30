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
    public BeatManager[] beatManagers;

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
        if (songPosition >= nextMeasureStartTime) {
            // Start of new measure
            measureCounter += 1;
            beatCounter = 0;
            SetBeatToSpawn(metadata.notes[measureCounter][beatCounter], nextMeasureStartTime);
            beatDuration = measureDuration / metadata.notes[measureCounter].Length;
            nextMeasureStartTime += measureDuration;
            nextBeatStartTime += beatDuration;
        }
        else if (songPosition >= nextBeatStartTime) {
            // Start of new beat
            beatCounter += 1;
            SetBeatToSpawn(metadata.notes[measureCounter][beatCounter], nextBeatStartTime);
            nextBeatStartTime += beatDuration;
        }
    }

    void SetBeatToSpawn(byte note, float spawnTime) {
        // Spawn a beat in each column where one is called for
        for (int i = 0; i < beatManagers.Length; i++) {
            if (IsBitSet(note, i)) {
                beatManagers[beatManagers.Length - i - 1].SpawnBeat(spawnTime);
            }
        }
    }

    bool IsBitSet(byte b, int num) {
        return (b & (1 << num)) != 0;
    }

    void PlaySong() {
        startDspTime = AudioSettings.dspTime;
        Debug.Log("startDspTime: " + startDspTime);
        music.PlayDelayed(BeatManager.beatSpawnOffsetTime);
    }
}
