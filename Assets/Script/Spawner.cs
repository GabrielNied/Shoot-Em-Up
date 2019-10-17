using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3, enemy4, boss, explosao, warning, hpbar, hpbarb, gameover, player;

    public float tempoSpawn1;
    public float tempoSpawn2;
    public float tempoSpawn3;
    public float tempoSpawn4;
    public bool nasceu = false;
    public float tempoBoss = 0;
    public float tempoExplosao1 = 0;
    public float tempoExplosao2 = 0;
    public ParticleSystem particleSystem;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        particleSystem = GetComponent<ParticleSystem>();
        int randomTempoI = Random.Range(0, 5);
        tempoSpawn1 += randomTempoI;

        int randomTempo2 = Random.Range(0, 5);
        tempoSpawn2 += randomTempo2;

        int randomTempo3 = Random.Range(0, 5);
        tempoSpawn3 += randomTempo3;

        int randomTempo4 = Random.Range(0, 5);
        tempoSpawn4 += randomTempo4;
    }

    void Update()
    {
        if (player.GetComponent<Player>().playerPontuacao <= 100)
        {
            tempoSpawn1 += Time.deltaTime;
            tempoSpawn2 += Time.deltaTime;
            tempoSpawn3 += Time.deltaTime;
            tempoSpawn4 += Time.deltaTime;

            if (tempoSpawn1 >= 5)
            {
                float random = Random.Range(-6.5f, 5.5f);
                transform.position = new Vector3(random, 6, 0);
                Instantiate(enemy1, transform.position, Quaternion.identity);

                if (player.GetComponent<Player>().playerPontuacao >= 1)
                {
                    float random1 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random1, 6, 0);
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 20)
                {
                    float random2 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random2, 6, 0);
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 30)
                {
                    float random3 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random3, 6, 0);
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                }

                int randomTempo = Random.Range(-5, 0);
                tempoSpawn1 = randomTempo;
            }

            if (tempoSpawn2 >= 15)
            {
                float random = Random.Range(-6.5f, 5.5f);
                transform.position = new Vector3(random, 6, 0);
                Instantiate(enemy2, transform.position, Quaternion.identity);

                if (player.GetComponent<Player>().playerPontuacao >= 15)
                {
                    float random1 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random1, 6, 0);
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 30)
                {
                    float random2 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random2, 6, 0);
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 45)
                {
                    float random3 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random3, 6, 0);
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                }

                int randomTempo = Random.Range(3, 8);
                tempoSpawn2 = randomTempo;
            }

            if (tempoSpawn3 >= 25)
            {
                float random = Random.Range(-6.5f, 5.5f);
                transform.position = new Vector3(random, 6, 0);
                Instantiate(enemy3, transform.position, Quaternion.identity);

                if (player.GetComponent<Player>().playerPontuacao >= 20)
                {
                    float random1 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random1, 6, 0);
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 40)
                {
                    float random2 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random2, 6, 0);
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 60)
                {
                    float random3 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random3, 6, 0);
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                }

                int randomTempo = Random.Range(0, 10);
                tempoSpawn3 = randomTempo;
            }

            if (tempoSpawn4 >= 35)
            {
                float random = Random.Range(-6.5f, 5.5f);
                transform.position = new Vector3(random, 6, 0);
                Instantiate(enemy4, transform.position, Quaternion.identity);

                if (player.GetComponent<Player>().playerPontuacao >= 25)
                {
                    float random1 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random1, 6, 0);
                    Instantiate(enemy4, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 50)
                {
                    float random2 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random2, 6, 0);
                    Instantiate(enemy4, transform.position, Quaternion.identity);
                }

                if (player.GetComponent<Player>().playerPontuacao >= 75)
                {
                    float random3 = Random.Range(-6.5f, 5.5f);
                    transform.position = new Vector3(random3, 6, 0);
                    Instantiate(enemy4, transform.position, Quaternion.identity);
                }

                int randomTempo = Random.Range(0, 10);
                tempoSpawn4 = randomTempo;
            }
        }

        if (player.GetComponent<Player>().playerPontuacao >= 100 && !nasceu)
        {
            warning.SetActive(true);
            tempoBoss += Time.deltaTime;
            if(tempoBoss >= 3)
            {
                Instantiate(boss, transform.position, Quaternion.identity);
                nasceu = true;
                warning.SetActive(false);
                hpbar.SetActive(true);
                hpbarb.SetActive(true);
            }
        }

        if(player.GetComponent<Player>().playerVida <= 0)
        {
            gameover.SetActive(true);            
        }

        if (nasceu)
        {
            tempoExplosao1 += Time.deltaTime;
            if (tempoExplosao1 >= 4)
            {
                int randomX = Random.Range(-6, 6);
                int randomY = Random.Range(-5, 5);
                var posicao = transform.position = new Vector2(randomX, randomY);
                explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
                Instantiate(explosao, posicao, Quaternion.identity);
                tempoExplosao1 = 0;
            }
        }

        if (nasceu)
        {
            tempoExplosao2 += Time.deltaTime;
            if (tempoExplosao2 >= 6)
            {
                int randomX = Random.Range(-6, 6);
                int randomY = Random.Range(-5, 5);
                var posicao = transform.position = new Vector2(randomX, randomY);
                explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
                Instantiate(explosao, posicao, Quaternion.identity);
                tempoExplosao2 = 0;
            }
        }
    }
}
