using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoAleatorio : MonoBehaviour
{
    public GameObject[] buttonsPreto;
    public GameObject[] buttonsRainbow;

    private bool eventoRodando = false;

    void Update()
    {
        if (Pontuacao.startou && !eventoRodando)
        {
            eventoRodando = true;
            StartCoroutine(ExecutarEventos());
            StartCoroutine(ChecarTrocaDeCena());
        }
    }

    IEnumerator ExecutarEventos()
    {
        while (eventoRodando)
        {
            yield return StartCoroutine(EventoBotaoPreto());
            yield return StartCoroutine(EventoBotaoRainbow());
            yield return new WaitForSeconds(Random.Range(1f, 6f));
        }
    }

    IEnumerator EventoBotaoPreto()
    {
        if (buttonsPreto.Length == 0) yield break;

        int chance = Random.Range(1, 3);
        if(chance == 1)
        {
            GameObject btn = buttonsPreto[Random.Range(0, buttonsPreto.Length)];
            btn.SetActive(true);
            yield return new WaitForSeconds(1f);
            btn.SetActive(false);
        }
    }

    IEnumerator EventoBotaoRainbow()
    {
        if (buttonsRainbow.Length == 0) yield break;

        int chance = Random.Range(1, 5); 
        if (chance == 1)
        {
            GameObject btnRainbow = buttonsRainbow[Random.Range(0, buttonsRainbow.Length)];
            btnRainbow.SetActive(true);
            yield return new WaitForSeconds(1f);
            btnRainbow.SetActive(false);
        }
    }

    IEnumerator ChecarTrocaDeCena()
    {
        while (eventoRodando)
        {
            yield return new WaitForSeconds(5f);

            int chanceCena = Random.Range(1, 3); 
            if (chanceCena == 1)
            {
                SceneManager.LoadScene("FaseDesafiadora"); 
                
            }
        }
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
