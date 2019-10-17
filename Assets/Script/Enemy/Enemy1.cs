using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{

    public GameObject explosao, powerup, player;

    public int enemyVida;

    public Rigidbody2D rbTiro;
    public float velTiro;
    public float tempoTiro = 0f;
    public int velEnemy = 1;
    public Vector2 aPosition1;
    public Vector2 aPosition2;
    public bool indo = true;
    public bool esquerdaI;
    public bool direitaI;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        int caseSwitch = Random.Range(1, 3);
        var distance = Vector2.Distance(transform.position, aPosition1);
        switch (caseSwitch)
        {
            case 1:
                aPosition1 = new Vector2(transform.position.x - 3, transform.position.y - 3);
                aPosition2 = new Vector2(transform.position.x + 6, transform.position.y - 6);

                esquerdaI = true;
                direitaI = false;
                distance = 0;
                break;
            case 2:
                aPosition1 = new Vector2(transform.position.x + 3, transform.position.y - 3);
                aPosition2 = new Vector2(transform.position.x - 6, transform.position.y - 6);
                esquerdaI = false;
                direitaI = true;
                distance = 0;
                break;
        }
    }

    void Update()
    {
        Movimentacao();
        Destroi();
    }

    void FixedUpdate()
    {
        tempoTiro -= Time.deltaTime;

        if (tempoTiro <= 0)
        {
            Atira();
            tempoTiro = 1f;
        }
    }

    void Movimentacao()
    {
        var distance = Vector2.Distance(transform.position, aPosition1);
        if (transform.position.x <= -6)
        {
            esquerdaI = false;
            direitaI = true;
            distance = 0;
        }
        if (transform.position.x >= 6)
        {
            esquerdaI = true;
            direitaI = false;
            distance = 0;
        }

        if (esquerdaI)
        {
            if (distance >= 0.5f && indo)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, velEnemy * Time.deltaTime);
            }
            else if (distance >= 3 && !indo)
            {
                aPosition1 = new Vector2(transform.position.x - 3, transform.position.y - 3);
                aPosition2 = new Vector2(transform.position.x + 6, transform.position.y - 6);
                indo = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition2, velEnemy * Time.deltaTime);
                indo = false;
            }
        }

        if (direitaI)
        {
            if (distance >= 0.5f && indo)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, velEnemy * Time.deltaTime);
            }
            else if (distance >= 3 && !indo)
            {
                aPosition1 = new Vector2(transform.position.x + 3, transform.position.y - 3);
                aPosition2 = new Vector2(transform.position.x - 6, transform.position.y - 6);
                indo = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition2, velEnemy * Time.deltaTime);
                indo = false;
            }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyVida = 0;
        }
        if (other.gameObject.tag == "TiroPlayer")
        {
            if (transform.position.y <= 5.3f)
            {
                enemyVida -= player.GetComponent<Player>().playerDano;
            }            
        }
    }

    void Destroi()
    {
        if (transform.position.y <= -8 || player.GetComponent<Player>().playerPontuacao >= 100)
        {
            Destroy(gameObject);
        }

        if (enemyVida <= 0)
        {
            Instantiate(explosao, transform.position, Quaternion.identity);
            DropPowerUp();
            player.GetComponent<Player>().playerPontuacao += 1;
            Destroy(gameObject);
        }
    }

    void DropPowerUp()
    {
        int caseSwitch = Random.Range(1, 6);
        switch (caseSwitch)
        {
            case 1:
                Instantiate(powerup, transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
