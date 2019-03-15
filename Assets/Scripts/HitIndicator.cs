using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitIndicator : MonoBehaviour {

    public Color perfect;
    public Color good;
    public Color hit;
    public Color miss;
    public float flashTime;

    private SpriteRenderer sprite;

    public IEnumerator Flash(int quality) {
        sprite.color = quality == 3 ? perfect : (quality == 2 ? good : (quality == 1 ? hit : miss));
        sprite.enabled = true;
        yield return new WaitForSeconds(flashTime);
        sprite.enabled = false;
    }

    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
}
