using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animator;
    public GameObject explosao, powerup, pMenu, cS, filho, powerupText, follower, powerupespecial;

    //Player
    public float playerVel = 10;
    public int playerVida = 3;
    public int playerPontuacao = 0;
    public int playerDano = 1;
    private Rigidbody2D rbPlayer;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    public bool imortal = false;
    public float tempoImortal = 0f;
    public float tempoPisca = 0f;

    //Tiro
    public Rigidbody2D rbTiro;
    public float velTiro = 20;
    public float tempoTiro = 0f;
    public bool tiroNormal = true;
    public float explosionStrength = 10.0f;
    //PowerUp
    /*
    public int powerUmTotal = 0;
    public int powerDoisTotal = 0;
    public bool powerUmAtivo = false;
    public bool powerDoisAtivo = false;
    public float tPowerUm = 0f;
    public float tPowerDois = 0f;
    */


    public float reduzTempoTiro;
    public bool tiroDuplo = false;
    public bool tiroTriplo = false;
    public float slowMotion = 0;
    public bool saiuSlow = false;

    public float especial;

    void Start()
    {
        pMenu = GameObject.Find("MenuManager");
        cS = GameObject.Find("CharacterSelection");
        powerupText = GameObject.Find("PowerupText");
        powerupText.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();

        if (cS.GetComponent<CharacterSelection>().nave == 1)
        {
            especial += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.LeftShift) && especial >= 20){
                Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone.velocity = new Vector2(0, velTiro);
                Rigidbody2D tiroClone1 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone1.velocity = new Vector2(-5, velTiro);
                Rigidbody2D tiroClone2 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone2.velocity = new Vector2(5, velTiro);
                Rigidbody2D tiroClone3 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone3.velocity = new Vector2(10, velTiro);
                Rigidbody2D tiroClone4 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone4.velocity = new Vector2(-10, velTiro);
                Rigidbody2D tiroClone5 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone5.velocity = new Vector2(15, velTiro);
                Rigidbody2D tiroClone6 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone6.velocity = new Vector2(-15, velTiro);
                Rigidbody2D tiroClone7 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone7.velocity = new Vector2(-20, velTiro);
                Rigidbody2D tiroClone8 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone8.velocity = new Vector2(20, velTiro);
                Rigidbody2D tiroClone9 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone9.velocity = new Vector2(30, velTiro);
                Rigidbody2D tiroClone10 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
                tiroClone10.velocity = new Vector2(-30, velTiro);
                especial = 0;
            }
        }

        if (cS.GetComponent<CharacterSelection>().nave == 2)
        {
            especial += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.LeftShift) && especial >= 20)
            {
                Instantiate(follower, transform);
                especial = 0;
            }
        }

        if (cS.GetComponent<CharacterSelection>().nave == 3)
        {
            especial += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.LeftShift) && especial >= 20)
            {
                float randomX = Random.Range(-5.5f, 5.5f);
                float randomY = Random.Range(-4, 4);
                Vector3 pos = new Vector3(randomX, randomY, 0);
                Instantiate(powerupespecial, pos, Quaternion.identity);
                especial = 0;
            }
        }

        //Sair da Tela
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.7f, maxScreenBounds.x - 0.7f), Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.7f, maxScreenBounds.y - 0.7f));

        //Movimentação
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rbPlayer.velocity = new Vector2(moveHorizontal * playerVel, moveVertical * playerVel);
        animator.SetFloat("Vel", Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical));

        //Tiro
        tempoTiro -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (tempoTiro <= 0 && pMenu.GetComponent<PauseMenu>().paused == false)
            {
                Atira();
                tempoTiro = 0.5f - reduzTempoTiro;
            }
        }

        //Dano
        if (imortal == true && tempoImortal >= 3)
        {
            imortal = false;
            if (cS.GetComponent<CharacterSelection>().nave == 1)
            {
                filho.gameObject.SetActive(true);
            }
            spriteRenderer.enabled = true;
            trailRenderer.enabled = true;
        }

        if (imortal)
        {
            Pisca();
        }

        Destroi();

        if (playerPontuacao >= 100 && !saiuSlow)
        {
            slowMotion += Time.deltaTime;
            
            if (slowMotion < 3)
            {
                Time.timeScale = 0.5f;
            }

            if (slowMotion >= 4)
            {
                Time.timeScale = 1;
                saiuSlow = true;
            }
        }
    }

    void FixedUpdate()
    {
        tempoImortal += Time.deltaTime;
        tempoPisca += Time.deltaTime;

        //PowerUp 10 sec
        /*
        tPowerUm += Time.deltaTime;
        tPowerDois += Time.deltaTime;

        if (tPowerUm >= 10 && powerUmAtivo == true)
        {
            playerVel -= powerUmTotal;
            powerUmTotal = 0;
            powerUmAtivo = false;
            Debug.Log("Finalizou 1");
        }

        if (tPowerDois >= 10 && powerDoisAtivo == true)
        {
            velTiro -= powerDoisTotal;
            powerDoisTotal = 0;
            powerDoisAtivo = false;
            Debug.Log("Finalizou 2");
        }
        */
    }

    void Atira()
    {
        animator.SetTrigger("Atirando");
        if (tiroNormal == true)
        {
            Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone.velocity = new Vector2(0, velTiro);
        }
        if (tiroDuplo == true)
        {
            Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone.GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x + 0.5f, transform.position.y);
            tiroClone.velocity = new Vector2(0, velTiro);
            Rigidbody2D tiroClone1 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone1.GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x - 0.5f, transform.position.y);
            tiroClone1.velocity = new Vector2(0, velTiro);
        }
        if (tiroTriplo == true)
        {
            Rigidbody2D tiroClone = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone.velocity = new Vector2(0, velTiro);
            Rigidbody2D tiroClone1 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone1.velocity = new Vector2(-10, velTiro);
            Rigidbody2D tiroClone2 = (Rigidbody2D)Instantiate(rbTiro, transform.position, transform.rotation);
            tiroClone2.velocity = new Vector2(10, velTiro);
        }
        //tiroClone.GetComponent<Tiro>().DoSomething();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TiroEnemy")
        {
            if (!imortal)
            {
                playerVida -= 1;
            }
            Imortal();
        }
        if (other.gameObject.tag == "Enemy")
        {
            if (!imortal)
            {
                playerVida -= 1;
            }
            Imortal();
        }

        if (other.gameObject.tag == "PowerUp")
        {
            if (playerVel >= 20 && velTiro >= 40 && playerVida >= 3 && playerDano >= 5 && reduzTempoTiro >= 0.4f && tiroTriplo)
            {

            }
            else
            {
                Pegou();
            }
        }
    }

    void Pisca()
    {
        if (tempoPisca >= 0.1f)
        {
            if (cS.GetComponent<CharacterSelection>().nave == 1)
            {
                filho.gameObject.SetActive(false);
            }
            spriteRenderer.enabled = !spriteRenderer.enabled;
            trailRenderer.enabled = !trailRenderer.enabled;
            tempoPisca = 0;
        }
    }

    void Imortal()
    {
        if (imortal)
        {

        }
        else
        {
            tempoImortal = 0;
            imortal = true;
        }
    }

    void Destroi()
    {
        if (playerVida <= 0)
        {
            Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void PowerUm()
    {
        playerVel += 1;
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "+ Speed";
        //  powerUmTotal += 5;
    }

    public void PowerDois()
    {
        velTiro += 2.5f;
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "+ Bullet Speed";
        //   powerDoisTotal += 5;
    }

    public void PowerTres()
    {
        playerVida += 1;
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "+ Life";
    }

    public void PowerQuatro()
    {
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "+ Damage";
        playerDano += 1;
    }

    public void PowerCinco()
    {
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "+ Fire rate";
        reduzTempoTiro += 0.1f;
    }

    public void PowerSeis()
    {
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "Double Shot";
        tiroDuplo = true;
        tiroNormal = false;
    }
    public void PowerSete()
    {
        powerupText.gameObject.SetActive(true);
        powerupText.GetComponent<Text>().text = "Triple Shot";
        tiroTriplo = true;
        tiroDuplo = false;
    }

    void Pegou()
    {
        int caseSwitch = Random.Range(1, 8);

        switch (caseSwitch)
        {
            case 1:

                if (playerVel < 15)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    //    tPowerUm = 0;
                    //    powerUmAtivo = true;
                    PowerUm();
                }
                else
                {
                    Pegou();
                }
                break;
            case 2:
                if (velTiro < 30)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    //      tPowerDois = 0;
                    //     powerDoisAtivo = true;
                    PowerDois();
                }
                else
                {
                    Pegou();
                }
                break;
            case 3:
                if (playerVida <= 2)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    PowerTres();
                }
                else
                {
                    Pegou();
                }
                break;
            case 4:
                if (playerDano <= 2)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    PowerQuatro();
                }
                else
                {
                    Pegou();
                }
                break;
            case 5:
                if (reduzTempoTiro < 0.3f)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    PowerCinco();
                }
                else
                {
                    Pegou();
                }
                break;
            case 6:
                if (tiroNormal)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    PowerSeis();
                }
                else
                {
                    Pegou();
                }
                break;
            case 7:
                if (tiroDuplo)
                {
                    Instantiate(powerup, transform.position, Quaternion.identity);
                    PowerSete();
                }
                else
                {
                    Pegou();
                }
                break;
        }
    }
}