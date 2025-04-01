using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoAleatorio : MonoBehaviour
{
    GameObject[] buttons;
    GameObject buttonToApear;
    // Start is called before the first frame update
    void Start()
    {
        while (true)
        {
            if (Pontuacao.startou)
            {
                StartCoroutine(EventoAleat());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Sorteia(GameObject btnToStart)
    {
        do
        {
            buttonToApear = buttons[Random.Range(0, buttons.Length)];
        }
        while (buttonToApear == btnToStart);
        SceneManager.LoadScene("DarkPhase");
        btnToStart.SetActive(false);
    }
    IEnumerator EventoAleat()
    {

        yield return new WaitForSeconds(10);

    }
}
