using UnityEngine;
using System.Collections;

public class TiroPlayer : MonoBehaviour
{

    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }     
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
