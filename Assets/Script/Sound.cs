using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Sound : MonoBehaviour
{
    public Slider Volume;
    public AudioSource som;
    public AudioSource som1;
    public GameObject player, outrosom, menu;

    public bool fading = false;
    public bool fadout = false;
    public bool terminou = false;

    public float volume = 1;

    public bool ativo = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        outrosom = GameObject.Find("SoundManager");

        if (outrosom.GetComponent<Sound>().ativo == true)
        {
            Destroy(gameObject);
        }

            ativo = true;
        
    }

    void Start()
    {

    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        menu = GameObject.Find("MenuManager");

        if (terminou || menu.GetComponent<PauseMenu>().paused == true)
        {
            som.volume = Volume.value;
            som1.volume = Volume.value;
        }

        if (player.GetComponent<Player>().playerPontuacao >= 100 && !terminou)
        {
            fading = true;
            fadeOut();
            fadeIn();
        }
    }

    void fadeOut()
    {
        if (fading == true)
        {
            fadout = true;
            if (som.volume > 0.1)
            {

                som.volume -= Time.deltaTime/2;
            }
            if (som.volume <= 0.1)
            {
                som.enabled = !enabled;
                fadout = false;

            }
        }
    }

    void fadeIn()
    {
        if (fading && !fadout)
        {
            if (som.enabled == !enabled)
            {
                som1.enabled = enabled;
                som1.volume += Time.deltaTime/4;
                if (som1.volume >= Volume.value)
                {
                    terminou = true;
                }
            }
        }
    }
}
