using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelectionCredits : MonoBehaviour
{

    int posicao = 1;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (posicao == 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
