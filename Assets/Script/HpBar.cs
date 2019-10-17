using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour
{
    public Image healthbar;
    public GameObject boss, player, hpbar, hpbarb, youwin;
    float vida;
    float dano;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        boss = GameObject.FindWithTag("Enemy");
        checkHealth();
        vida = boss.GetComponent<Boss>().enemyVidaAtual;
        dano = player.GetComponent<Player>().playerDano;
        if (vida <= 0)
        {
            hpbar.SetActive(false);
            hpbarb.SetActive(false);
            youwin.SetActive(true);
        }
    }
    public void checkHealth()
    {
        healthbar.rectTransform.localScale = new Vector3(vida / 1000, healthbar.rectTransform.localScale.y, healthbar.rectTransform.localScale.z);
    }

    
}