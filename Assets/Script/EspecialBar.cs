using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EspecialBar : MonoBehaviour
{
    public Image especialbar;
    public GameObject  player, espeicalbar, especialbarb;
    float vida;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        checkHealth();
        vida = player.GetComponent<Player>().playerVida;
        if (vida <= 0)
        {
            espeicalbar.SetActive(false);
            especialbarb.SetActive(false);
        }
    }

    public void checkHealth()
    {
        if (player.GetComponent<Player>().especial <= 20)
        {
            especialbar.rectTransform.localScale = new Vector3(especialbar.rectTransform.localScale.x, player.GetComponent<Player>().especial / 20, especialbar.rectTransform.localScale.z);
        }
    }

    
}