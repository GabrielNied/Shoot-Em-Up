using UnityEngine;
using System.Collections;

public class TiroEnemy3 : MonoBehaviour
{
    public GameObject player;
    public Enemy3 enemy3;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "TiroPlayer")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
