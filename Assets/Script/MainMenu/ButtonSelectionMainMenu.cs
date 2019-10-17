using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelectionMainMenu : MonoBehaviour
{

    int posicao = 1;
    public int opcoes = 3;
    public float anda = 3f;

    void Start()
    {

    }

    void Update()
    {
        if (posicao == 1)
        {
            transform.position = new Vector3(-2.30f, 0.25f, 0);
        }

        if (posicao == 2)
        {
            transform.position = new Vector3(-2f, -0.95f, 0);
        }

        if (posicao == 3)
        {
            transform.position = new Vector3(-1.09f, -2.18f, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (posicao < opcoes)
            {
                posicao++;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (posicao > 1)
            {
                posicao--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (posicao == 1)
            {
                SceneManager.LoadScene(2);
            }

            else if (posicao == 2)
            {
                SceneManager.LoadScene(1);
            }

            else if (posicao == 3)
            {
                Application.Quit();
            }
        }
    }
}
