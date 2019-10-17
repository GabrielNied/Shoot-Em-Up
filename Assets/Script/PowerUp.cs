using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float tempo = 0;

    public int random;
    public Sprite img1, img2, img3, img4;

    void Start()
    {
        int random = Random.Range(1, 5);
        Debug.Log("random:" + random);
        if (random == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = img1;
        }
        if (random == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = img2;
        }
        if (random == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = img3;
        }
        if (random == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = img4;
        }
    }


    void FixedUpdate()
    {
        tempo += Time.deltaTime;

        if (tempo >= 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
