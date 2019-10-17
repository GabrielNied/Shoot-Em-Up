using UnityEngine;
using System.Collections;

public class MudarCor : MonoBehaviour
{

    public Color color1;
    public Color color2;
    public Color color3;
    public Color current;
    public Color bgcolor;

    public float duration = 3.0F;
    public float cabou = 0;
    public float trocaCor = 0;

    public GameObject player;
    Camera camera;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        current = camera.backgroundColor;
        bgcolor = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        
        if (cabou <= 5)
        {
            if (player.GetComponent<Player>().playerPontuacao >= 100)
            {
                cabou += Time.deltaTime;
                float t = Mathf.PingPong(Time.time, duration) / duration;
                camera.backgroundColor = Color.Lerp(color1, color2, t);
            }
        }
       if (cabou >=5)
        {
            Change_color();
        }

        if (player.GetComponent<Player>().playerPontuacao >= 50 && player.GetComponent<Player>().playerPontuacao < 100)
        {
            Change_color();
        }
    }
    void Change_color()
    {
        if (trocaCor >= 5)
        {
            current = camera.backgroundColor;
            bgcolor = new Color(Random.value, Random.value, Random.value);
            trocaCor = 0;
        }
        trocaCor += Time.deltaTime;
        float t = Mathf.PingPong(Time.time, duration) / duration;
        camera.backgroundColor = Color.Lerp(current, bgcolor, t);
    }
}