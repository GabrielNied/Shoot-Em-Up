using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelection : MonoBehaviour {

    int posicao = 1;
    public int opcoes = 3;
    public float anda = 3f;

    public GameObject coelho, gato, rato;
    public CharacterSelection charS;

	void Start () {
		
	}
	
	void Update () {
        if (posicao == 1)
        {
            coelho.SetActive(true);
            gato.SetActive(false);
            rato.SetActive(false);
            transform.position = new Vector3(-2.63f, 1.3f, 0);
        }
        if(posicao == 2)
        {
            transform.position = new Vector3(2.71f, 1.3f, 0);
            coelho.SetActive(false);
            gato.SetActive(true);
            rato.SetActive(false);
        }
        if (posicao == 3)
        {            
            coelho.SetActive(false);
            gato.SetActive(false);
            rato.SetActive(true);
            transform.position = new Vector3(0.04f, -2.55f, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (posicao < opcoes)
            {
                posicao++;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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
                    SceneManager.LoadScene(3);
                    charS.nave = 1;
                }

                else if (posicao == 2)
                {
                    SceneManager.LoadScene(3);
                    charS.nave = 2;
                }

                else if (posicao == 3) { 
                SceneManager.LoadScene(3);
                charS.nave = 3;
            }
        }
    }
}
