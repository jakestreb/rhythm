using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public BeatManager[] beatManagers;
    public SpriteRenderer[] beatTargets;
    public string[] beatKeys;
    public Color inactiveTarget;
    public Color activeTarget;

	void Update () {
        // Handle beat target activations
        for (int i = 0; i < beatKeys.Length; i++) {
            if (Input.GetKeyDown(beatKeys[i])) {
                beatManagers[i].HitBeat();
                beatTargets[i].color = activeTarget;
            } else {
                beatTargets[i].color = inactiveTarget;
            }
        }

        if (Input.GetKeyDown("1")) {
            StartCoroutine(ActivatePowerup1());
        }
    }

    IEnumerator ActivatePowerup1 () {
        for (int i = 0; i < beatManagers.Length; i++) {
            beatManagers[i].spawnDelay = Random.value * 0.7f;
        }
        yield return new WaitForSeconds(10.0f);
        for (int i = 0; i < beatManagers.Length; i++) {
            beatManagers[i].spawnDelay = 0.0f;
        }
    }
}
