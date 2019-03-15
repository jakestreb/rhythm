using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMetadata : MonoBehaviour {

    public readonly float bpm = 140.0f;
    public readonly float offset = 0.0f;  // Excess time at the beginning of the song
    public int[][] notes = {
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 1, 0, 0, 0 },
        new int[] { 0, 1, 0, 0, 1, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 1, 1, 0 },
        new int[] { 1, 0, 1, 0, 1, 1, 0, 1 },
        new int[] { 1, 0, 1, 1, 0, 1, 0, 0 },
        new int[] { 1, 0, 0, 0, 1, 0, 1, 1 },
        new int[] { 0, 0, 0, 0, 0, 1, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 0, 1, 0, 0, 1, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 1, 0, 0, 0 },
        new int[] { 0, 1, 0, 0, 1, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 1, 1, 0 },
        new int[] { 1, 0, 1, 0, 1, 1, 0, 1 },
        new int[] { 1, 0, 1, 1, 0, 1, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 0, 1, 0, 0, 1, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 1, 0, 0, 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 },
        new int[] { 0 }
    };
}
