using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour
{

    public GameObject explosao, powerup, player, filho, filho2;

    public int enemyVida;

    public Rigidbody2D rbTiro;
    public float velTiro;
    public float tempoTiro = 0f;
    public int velEnemy = 1;
    public Vector2 aPosition1;
    public Vector2 aPosition2;
    public Vector2 aPosition3;
    public Vector2 aPosition4;
    bool indo1 = true;
    bool indo2 = false;
    bool indo3 = false;

    public float tempoPisca;
    public float tempoPiscando;
    public bool pisca = false;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        player = GameObject.FindWithTag("Player");
        transform.position = new Vector2(0, 6);
        aPosition1 = new Vector2(transform.position.x, transform.position.y - 6);
    }

    void Update()
    {
        Movimentacao();
        Destroi();
    }

    void FixedUpdate()
    {
        tempoTiro -= Time.deltaTime;
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
            filho.gameObject.SetActive(true);
            filho2.gameObject.SetActive(true);
            trailRenderer.enabled = true;
        }

        if (tempoTiro <= 0)
        {
            Atira();
            tempoTiro = 0.5f;
        }
    }

    void Pisca()
    {
        if (tempoPisca >= 0.2f && tempoPiscando < 0.6f)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            filho.gameObject.SetActive(false);
            filho2.gameObject.SetActive(false);
            trailRenderer.enabled = !trailRenderer.enabled;
            tempoPisca = 0;
        }
    }

    void Movimentacao()
    {
        var distance1 = Vector2.Distance(transform.position, aPosition1);

        if (transform.position.x <= -6)
        {
            indo2 = false;
            indo3 = true;
        }

        if (transform.position.x >= 6)
        {
            indo2 = false;
            indo3 = true;
        }

        if (distance1 <= 0)
        {
            indo1 = false;
            indo2 = true;
            int caseSwitch = Random.Range(1, 3);
            switch (caseSwitch)
            {
                case 1:
                    aPosition2 = new Vector2(transform.position.x - 10, transform.position.y);
                    break;
                case 2:
                    aPosition2 = new Vector2(transform.position.x + 10, transform.position.y);
                    break;
            }
        }

        if (indo3)
        {
            aPosition3 = new Vector2(transform.position.x, transform.position.y - 10);
        }

        if (indo1)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, velEnemy * Time.deltaTime);
        }

        if (indo2)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition2, velEnemy * Time.deltaTime);
        }
        if (indo3)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition3, velEnemy * Time.deltaTime);
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
                tempoPiscando = 0;
                pisca = true;
            }
        }
    }

    void Destroi()
    {
        if (transform.position.y <= -8 || player.GetComponent<Player>().playerPontuacao >= 100)
        {
            Destroy(gameObject);
        }

        if (enemyVida <= 0 )
        {
            Instantiate(explosao, transform.position, Quaternion.identity);
            DropPowerUp();
            player.GetComponent<Player>().playerPontuacao += 3;
            Destroy(gameObject);
        }
    }

    void DropPowerUp()
    {
        int caseSwitch = Random.Range(1, 4);
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
