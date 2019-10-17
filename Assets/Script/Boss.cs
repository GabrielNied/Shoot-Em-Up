using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{

    public GameObject explosao, player, hpbar;

    public float enemyVidaAtual;
    public int enemyVidaTotal = 1000;
    public Animator animator;

    public Rigidbody2D rbTiro;
    public float velTiro;
    public float tempoTiro = 0f;
    public float velEnemy = 1;
    public Vector2 aPosition1;
    public Vector2 aPosition2;
    public Vector2 aPosition3;
    public Vector2 aPosition4;
    public Vector2 aPosition5;
    public Vector2 aPosition6;
    public Vector2 aPosition7;
    public Vector2 aPosition8;
    public Vector2 aPosition9;
    public Vector2 aPosition10;
    bool indo1 = true;
    bool indo2 = false;
    bool indo3 = false;
    bool indo4 = false;
    bool indo5 = false;
    bool indo6 = false;
    bool indo7 = false;
    bool indo8 = false;
    bool indo9 = false;
    bool indo10 = false;

    public bool destruiu = false;
    public float levouDano = 1;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;

    public float tempoVivo = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        player = GameObject.FindWithTag("Player");
        transform.position = new Vector2(0, 8);
        aPosition1 = new Vector2(0, 3.5f);
        enemyVidaAtual = enemyVidaTotal;
        hpbar = GameObject.FindWithTag("UI");
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Movimentacao();
        Destroi();
        tempoTiro -= Time.deltaTime;
        tempoVivo += Time.deltaTime/20;

        if (tempoTiro <= 0)
        {
            Atira();
            tempoTiro = 1f;
        }

        levouDano += Time.deltaTime;
        if (levouDano >= 0.1)
        {
            spriteRenderer.color = new Color(1, 0.92f, 0.016f, 1);
        }

        if (velEnemy <= 5)
        {
            velEnemy = tempoVivo;
        }

        if (trailRenderer.time >= 0.5)
        {
            trailRenderer.time -= tempoVivo / 20000;
        }
    }

    void Movimentacao()
    {
        if (indo1)
        {
            var distance1 = Vector2.Distance(transform.position, aPosition1);

            if (distance1 <= 0)
            {
                indo1 = false;
                indo2 = true;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = false;

                aPosition2 = new Vector2(5, 3.5f);
            }
        }

        if (indo2)
        {
            var distance2 = Vector2.Distance(transform.position, aPosition2);
            if (distance2 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = true;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = false;

                aPosition3 = new Vector2(-5, 3.5f);

            }
        }
        if (indo3)
        {
            var distance3 = Vector2.Distance(transform.position, aPosition3);
            if (distance3 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = true;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = false;

                aPosition4 = new Vector2(0, 0);

            }
        }
        if (indo4)
        {
            var distance4 = Vector2.Distance(transform.position, aPosition4);
            if (distance4 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = true;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = false;
                aPosition5 = new Vector2(5 , 3.5f);
            }
        }
        if (indo5)
        {
            var distance5 = Vector2.Distance(transform.position, aPosition5);
            if (distance5 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = true;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = false;
                aPosition6 = new Vector2(0, 3.5f);
            }
        }
        if (indo6)
        {
            var distance6 = Vector2.Distance(transform.position, aPosition6);
            if (distance6 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = true;
                indo8 = false;
                indo9 = false;
                indo10 = false;

                        aPosition7 = new Vector2(0, -3);
            }
        }

        if (indo7)
        {
            var distance7 = Vector2.Distance(transform.position, aPosition7);
            if (distance7 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = true;
                indo9 = false;
                indo10 = false;


                aPosition8 = new Vector2(0, 3.5f);
            }
        }

        if (indo8)
        {
            var distance8 = Vector2.Distance(transform.position, aPosition8);
            if (distance8 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = true;
                indo10 = false;

                    aPosition9 = new Vector2(-5,0);
               
            }
        }
        if (indo9)
        {
            var distance9 = Vector2.Distance(transform.position, aPosition9);
            if (distance9 <= 0)
            {
                indo1 = false;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = true;
                
                    aPosition10 = new Vector2(5, 0);
                

            }
        }
        if (indo10)
        {
            var distance10 = Vector2.Distance(transform.position, aPosition10);
            if (distance10 <= 0)
            {
                indo1 = true;
                indo2 = false;
                indo3 = false;
                indo4 = false;
                indo5 = false;
                indo6 = false;
                indo7 = false;
                indo8 = false;
                indo9 = false;
                indo10 = false;
            }
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

        if (indo4)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition4, velEnemy * Time.deltaTime);
        }

        if (indo5)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition5, velEnemy * Time.deltaTime);
        }

        if (indo6)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition6, velEnemy * Time.deltaTime);
        }

        if (indo7)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition7, velEnemy * Time.deltaTime);
        }

        if (indo8)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition8, velEnemy * Time.deltaTime);
        }

        if (indo9)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition9, velEnemy * Time.deltaTime);
        }

        if (indo10)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition10, velEnemy * Time.deltaTime);
        }
    }

    void Atira()
    {
        if (transform.position.y <= 5 && enemyVidaAtual >500)
        {
            Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone.velocity = new Vector2(0, velTiro);
        }
        if (enemyVidaAtual <= 500)
        {
            Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone.velocity = new Vector2(0, velTiro);
            Rigidbody2D tiroClone1 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone1.velocity = new Vector2(-5, velTiro);
            Rigidbody2D tiroClone2 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone2.velocity = new Vector2(5, velTiro);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            levouDano = 0;

        }
        if (other.gameObject.tag == "TiroPlayer")
        {
            if (transform.position.y <= 5.3f)
            {
                enemyVidaAtual -= player.GetComponent<Player>().playerDano;
                spriteRenderer.color = new Color(1, 0, 0, 1);
                levouDano = 0;
            }
        }
    }

    void Destroi()
    {
        if (transform.position.y <= -6)
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

        if (enemyVidaAtual <= 0)
        {
            indo1 = false;
            indo2 = false;
            indo3 = false;
            indo4 = false;
            indo5 = false;
            indo6 = false;
            indo7 = false;
            indo8 = false;
            indo9 = false;
            indo10 = false;
            Instantiate(explosao, transform.position, Quaternion.identity);
            player.GetComponent<Player>().playerPontuacao += 50;
            Destroy(gameObject);
        }
    }
}
