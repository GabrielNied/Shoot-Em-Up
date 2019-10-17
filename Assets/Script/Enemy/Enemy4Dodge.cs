using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Dodge : MonoBehaviour
{

    public GameObject enemy4;

    public Vector2 fugir;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemy4.GetComponent<Enemy4>().direitaI)
            {
                fugir = new Vector2(other.transform.position.x, other.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, fugir, -1 * enemy4.GetComponent<Enemy4>().velEnemy * Time.deltaTime);

                enemy4.GetComponent<Enemy4>().velEnemy += 5;
                enemy4.GetComponent<Enemy4>().aPosition1 = new Vector2(transform.position.x + 12, transform.position.y - 12);
                enemy4.GetComponent<Enemy4>().direitaI = false;
                enemy4.GetComponent<Enemy4>().esquerdaI = true;
            }

            else
            {
                fugir = new Vector2(other.transform.position.x, other.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, fugir, -1 * enemy4.GetComponent<Enemy4>().velEnemy * Time.deltaTime);
                enemy4.GetComponent<Enemy4>().velEnemy += 5;
                enemy4.GetComponent<Enemy4>().aPosition2 = new Vector2(transform.position.x - 12, transform.position.y - 12);
                enemy4.GetComponent<Enemy4>().esquerdaI = false;
                enemy4.GetComponent<Enemy4>().direitaI = true;
            }
        }

        if (other.gameObject.tag == "TiroPlayer")
        {
            if (enemy4.GetComponent<Enemy4>().direitaI)
            {
                fugir = new Vector2(other.transform.position.x, other.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, fugir, -1 * enemy4.GetComponent<Enemy4>().velEnemy * Time.deltaTime);
                enemy4.GetComponent<Enemy4>().velEnemy += 5;
                enemy4.GetComponent<Enemy4>().aPosition1 = new Vector2(transform.position.x + 12, transform.position.y - 12);
                enemy4.GetComponent<Enemy4>().direitaI = false;
                enemy4.GetComponent<Enemy4>().esquerdaI = true;

            }
            else
            {
                fugir = new Vector2(other.transform.position.x, other.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, fugir, -1 * enemy4.GetComponent<Enemy4>().velEnemy * Time.deltaTime);
                enemy4.GetComponent<Enemy4>().velEnemy += 5;
                enemy4.GetComponent<Enemy4>().aPosition2 = new Vector2(transform.position.x - 12, transform.position.y - 12);
                enemy4.GetComponent<Enemy4>().esquerdaI = false;
                enemy4.GetComponent<Enemy4>().direitaI = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy4.GetComponent<Enemy4>().velEnemy -= 5;
        }

        if (other.gameObject.tag == "TiroPlayer")
        {
            enemy4.GetComponent<Enemy4>().velEnemy -= 5;
        }
    }
}
