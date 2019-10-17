using UnityEngine;
using System.Collections;

public class Enemy4 : MonoBehaviour
{

    public GameObject explosao, powerup, player, filho;

    public int enemyVida;

    public Rigidbody2D rbTiro;
    public float velTiro;
    public float tempoTiro = 0f;
    public int velEnemy = 1;
    public Vector2 aPosition1;
    public Vector2 aPosition2;
    public bool esquerdaI = false;
    public bool direitaI = false;


    public float tempoPisca;
    public float tempoPiscando;
    public bool pisca = false;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();

        transform.position = new Vector2(7.5f, 6);
        aPosition1 = new Vector2(transform.position.x - 36, transform.position.y - 28);
        int caseSwitch = Random.Range(1, 3);
        var distance = Vector2.Distance(transform.position, aPosition1);
        switch (caseSwitch)
        {
            case 1:
                transform.position = new Vector2(-6, 6);
                aPosition1 = new Vector2(transform.position.x + 12, transform.position.y - 12);
                direitaI = false;
                esquerdaI = true;
                break;
            case 2:
                transform.position = new Vector2(6, 6);
                aPosition2 = new Vector2(transform.position.x - 12, transform.position.y - 12);
                esquerdaI = false;
                direitaI = true;
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
        tempoPisca += Time.deltaTime;
        tempoPiscando += Time.deltaTime;
        if (pisca)
        {
            Pisca();
        }
        if (tempoPiscando >= 0.6f)
        {
            pisca = false;
            filho.gameObject.SetActive(true);
            spriteRenderer.enabled = true;
            trailRenderer.enabled = true;
        }
        tempoTiro -= Time.deltaTime;

        if (tempoTiro <= 0)
        {
            Atira();
            tempoTiro = 1f;
        }
    }

    void Pisca()
    {
        if (tempoPisca >= 0.2f && tempoPiscando < 0.6f)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            filho.gameObject.SetActive(false);
            trailRenderer.enabled = !trailRenderer.enabled;
            tempoPisca = 0;
        }
    }

    void Movimentacao()
    {
        if (esquerdaI)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, velEnemy * Time.deltaTime);
        }

        if (direitaI)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition2, velEnemy * Time.deltaTime);
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

            if (direitaI)
            {
                aPosition1 = new Vector2(transform.position.x + 12, transform.position.y - 12);
                direitaI = false;
                esquerdaI = true;

            }
            else
            {
                aPosition2 = new Vector2(transform.position.x - 12, transform.position.y - 12);
                esquerdaI = false;
                direitaI = true;
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
            player.GetComponent<Player>().playerPontuacao += 4;
            Destroy(gameObject);
        }
    }

    void DropPowerUp()
    {
        int caseSwitch = Random.Range(1, 3);
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
