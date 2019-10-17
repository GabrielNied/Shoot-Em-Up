using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text vida;
    public Text pontuacao;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "Vida: " + player.GetComponent<Player>().playerVida;
        pontuacao.text = "" + player.GetComponent<Player>().playerPontuacao;
    }
}
