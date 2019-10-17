using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject player, nave1, nave2, nave3, cS, ratovida1, ratovida2, ratovida3, gatovida1, gatovida2, gatovida3, coelhovida1, coelhovida2, coelhovida3;

    void Awake () {
        cS = GameObject.Find("CharacterSelection");

        if (cS.GetComponent<CharacterSelection>().nave == 1)
        {
            coelhovida1.SetActive(true);
            coelhovida2.SetActive(true);
            coelhovida3.SetActive(true);
            Instantiate(nave1, transform.position, Quaternion.identity);
        }
        if (cS.GetComponent<CharacterSelection>().nave == 2)
        {
            gatovida1.SetActive(true);
            gatovida2.SetActive(true);
            gatovida3.SetActive(true);
            Instantiate(nave2, transform.position, Quaternion.identity);
        }
        if (cS.GetComponent<CharacterSelection>().nave == 3)
        {
            ratovida1.SetActive(true);
            ratovida2.SetActive(true);
            ratovida3.SetActive(true);
            Instantiate(nave3, transform.position, Quaternion.identity);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update () {
        if (cS.GetComponent<CharacterSelection>().nave == 1)
        {
                if (player.GetComponent<Player>().playerVida == 0)
                {

                    coelhovida1.SetActive(false);
                    coelhovida2.SetActive(false);
                    coelhovida3.SetActive(false);
                }

                if (player.GetComponent<Player>().playerVida == 1)
                {

                    coelhovida1.SetActive(true);
                    coelhovida2.SetActive(false);
                    coelhovida3.SetActive(false);
                }

                if (player.GetComponent<Player>().playerVida == 2)
                {

                    coelhovida1.SetActive(true);
                    coelhovida2.SetActive(true);
                    coelhovida3.SetActive(false);
                }

                if (player.GetComponent<Player>().playerVida == 3)
                {

                    coelhovida1.SetActive(true);
                    coelhovida2.SetActive(true);
                    coelhovida3.SetActive(true);
                }
            
        }

        if (cS.GetComponent<CharacterSelection>().nave == 2)
        {
            if (player.GetComponent<Player>().playerVida == 0)
            {
                gatovida1.SetActive(false);
                gatovida2.SetActive(false);
                gatovida3.SetActive(false);
            }

            if (player.GetComponent<Player>().playerVida == 1)
            {
                gatovida1.SetActive(true);
                gatovida2.SetActive(false);
                gatovida3.SetActive(false);
            }

            if (player.GetComponent<Player>().playerVida == 2)
            {
                gatovida1.SetActive(true);
                gatovida2.SetActive(true);
                gatovida3.SetActive(false);
            }

            if (player.GetComponent<Player>().playerVida == 3)
            {
                gatovida1.SetActive(true);
                gatovida2.SetActive(true);
                gatovida3.SetActive(true);
            }
        }

        if (cS.GetComponent<CharacterSelection>().nave == 3)
        {
            if (player.GetComponent<Player>().playerVida == 0)
            {
                ratovida1.SetActive(false);
                ratovida2.SetActive(false);
                ratovida3.SetActive(false);
            }

            if (player.GetComponent<Player>().playerVida == 1)
            {
                ratovida1.SetActive(true);
                ratovida2.SetActive(false);
                ratovida3.SetActive(false);
            }

            if (player.GetComponent<Player>().playerVida == 2)
            {
                ratovida1.SetActive(true);
                ratovida2.SetActive(true);
                ratovida3.SetActive(false);
            }

            if (player.GetComponent<Player>().playerVida == 3)
            {
                ratovida1.SetActive(true);
                ratovida2.SetActive(true);
                ratovida3.SetActive(true);
            }
        }
    }
}
