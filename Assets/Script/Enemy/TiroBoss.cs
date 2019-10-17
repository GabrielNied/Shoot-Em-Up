using UnityEngine;
using System.Collections;

public class TiroBoss : MonoBehaviour
{
    public GameObject player;
    public Boss boss;

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
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
