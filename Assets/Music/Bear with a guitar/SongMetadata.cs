﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMetadata : MonoBehaviour {

    public readonly float bpm = 140.0f;
    public readonly float offset = 0.0f;  // Excess time at the beginning of the song
    public byte[][] notes = {
        new byte[] { 0x4, 0x0, 0x0, 0x6, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x6, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x6, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x6, 0x6, 0x0, 0x0, 0x0 },
        new byte[] { 0x0, 0x4, 0x0, 0x0, 0x6, 0x0, 0x0, 0x0 },
        new byte[] { 0x2, 0x0, 0x0, 0x4, 0x0, 0x2, 0x2, 0x0 },
        new byte[] { 0x2, 0x0, 0x4, 0x0, 0x2, 0x4, 0x0, 0x2 },
        new byte[] { 0x4, 0x0, 0x4, 0x4, 0x0, 0x2, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x0, 0x2, 0x0, 0x4, 0x6 },
        new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x0, 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x4, 0x4, 0x0, 0x0, 0x0 },
        new byte[] { 0x0, 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0 },
        new byte[] { 0x2, 0x0, 0x0, 0x4, 0x0, 0x2, 0x2, 0x0 },
        new byte[] { 0x2, 0x0, 0x4, 0x0, 0x2, 0x4, 0x0, 0x2 },
        new byte[] { 0x2, 0x0, 0x2, 0x2, 0x0, 0x2, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x0, 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0 },
        new byte[] { 0x4, 0x0, 0x0, 0x4, 0x4, 0x0, 0x0, 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
        new byte[] { 0x0 },
    };
}
