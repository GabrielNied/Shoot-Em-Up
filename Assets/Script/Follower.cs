using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public Rigidbody2D rbTiro;
    public float velTiro;
    public float tempoTiro = 0f;

    public float tempoVivo = 0;

    void Start () {
		
	}

    void FixedUpdate()
    {
        tempoTiro -= Time.deltaTime;
        tempoVivo += Time.deltaTime;
        if (tempoVivo >= 10)
        {
            Destroy(gameObject);
        }

        if (tempoTiro <= 0)
        {
            Atira();
            tempoTiro = 1f;
        }
    }

    void Atira()
    {
        if (transform.position.y <= 5)
        {
            Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone.velocity = new Vector2(0, velTiro);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
