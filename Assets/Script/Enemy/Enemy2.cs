using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
    public GameObject explosao, powerup, player;

    public int enemyVida;
    public int enemyDano;
    public float tempoPisca;
    public float tempoPiscando;
    public bool pisca = false;
    public float velEnemy;
    public Vector2 aPosition1;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        
    }
    
    void FixedUpdate()
    {
        tempoPisca += Time.deltaTime;
        tempoPiscando += Time.deltaTime;
        if (pisca)
        {
            Pisca();
        }
        if (tempoPiscando >= 0.6f)
        {
            pisca = false;
            spriteRenderer.enabled = true;
            trailRenderer.enabled = true;
        }
        Movimentacao();
        Destroi();
    }

    void Movimentacao()
    {
        aPosition1 = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, velEnemy * Time.deltaTime);
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
                tempoPiscando = 0;
                pisca = true;

            }
        }
    }

    void Pisca()
    {
        if (tempoPisca >= 0.2f && tempoPiscando <0.6f)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            trailRenderer.enabled = !trailRenderer.enabled;
            tempoPisca = 0;
        }
    }

    void Destroi()
    {
        if (transform.position.y <= -8 || player.GetComponent<Player>().playerPontuacao >= 100)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= -8)
        {
            Destroy(gameObject);
        }

        if (transform.position.x >= 8)
        {
            Destroy(gameObject);
        }



        if (enemyVida <= 0)
        {
            Instantiate(explosao, transform.position, Quaternion.identity);
            DropPowerUp();
            player.GetComponent<Player>().playerPontuacao += 2;

            Destroy(gameObject);
        }
    }

    void DropPowerUp()
    {
        int caseSwitch = Random.Range(1, 5);
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
