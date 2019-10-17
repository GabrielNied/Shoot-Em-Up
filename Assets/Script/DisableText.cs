using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableText : MonoBehaviour
{

    public GameObject textopu;

    void Start()
    {

    }

    public void Desativa()
    {
        textopu.gameObject.SetActive(false);
    }

    void Update()
    {

    }
}
