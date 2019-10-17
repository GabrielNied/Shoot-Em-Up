using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCredits : MonoBehaviour
{
    public GameObject explosao;

    public float tempoExplosao1 = 0;
    public float tempoExplosao2 = 0;
    public float tempoExplosao3 = 0;
    public float tempoExplosao4 = 0;
    public ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
     
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            int randomX = Random.Range(-6, 6);
            int randomY = Random.Range(-5, 5);
            var posicao = transform.position = new Vector2(randomX, randomY);
            explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            Instantiate(explosao, posicao, Quaternion.identity);
        }

        tempoExplosao1 += Time.deltaTime;
        if (tempoExplosao1 >= 2)
        {
            int randomX = Random.Range(-6, 6);
            int randomY = Random.Range(-5, 5);
            var posicao = transform.position = new Vector2(randomX, randomY);
            explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            Instantiate(explosao, posicao, Quaternion.identity);
            tempoExplosao1 = Random.Range(-5, 0);
        }

        tempoExplosao2 += Time.deltaTime;
        if (tempoExplosao2 >= 3)
        {
            int randomX = Random.Range(-6, 6);
            int randomY = Random.Range(-5, 5);
            var posicao = transform.position = new Vector2(randomX, randomY);
            explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            Instantiate(explosao, posicao, Quaternion.identity);
            tempoExplosao2 = Random.Range(-5, 1);
        }
        tempoExplosao3 += Time.deltaTime;
        if (tempoExplosao3 >= 4)
        {
            int randomX = Random.Range(-6, 6);
            int randomY = Random.Range(-5, 5);
            var posicao = transform.position = new Vector2(randomX, randomY);
            explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            Instantiate(explosao, posicao, Quaternion.identity);
            tempoExplosao3 = Random.Range(-5, 2);
        }

        tempoExplosao4 += Time.deltaTime;
        if (tempoExplosao4 >= 5)
        {
            int randomX = Random.Range(-6, 6);
            int randomY = Random.Range(-5, 5);
            var posicao = transform.position = new Vector2(randomX, randomY);
            explosao.GetComponent<ParticleSystem>().startColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            Instantiate(explosao, posicao, Quaternion.identity);
            tempoExplosao4 = Random.Range(-5, 3);
        }
    }
}
