using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject menu, tempo;
    public bool paused = false;
    public bool despausou = false;
    public float tempoVolta = 1;
    public Text textotempoVolta;

    void Start()
    {
        menu.SetActive(false);
        tempo.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (!paused)
            {
                despausou = true;
            }
        }

        if (paused)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            tempoVolta = 0.6f;
            AudioListener.pause = true;
        }

        if (!paused)
        {
            menu.SetActive(false);
            AudioListener.pause = false;
        }

        if (despausou)
        {
            Volta();
        }
    }

    void Volta() {
        tempoVolta += Time.deltaTime *10;

        if (tempoVolta < 3) {
            Time.timeScale = 0.1f;
            tempo.SetActive(true);
            textotempoVolta.text = "" + tempoVolta.ToString("f0"); ;
        }

        if (tempoVolta >= 3)
        {
            Time.timeScale = 1;
            tempo.SetActive(false);
            despausou = false;
        }
    }

    public void Back()
    {
        paused = false;
        despausou = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
