using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiParticula : MonoBehaviour {
    void Start () {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}
