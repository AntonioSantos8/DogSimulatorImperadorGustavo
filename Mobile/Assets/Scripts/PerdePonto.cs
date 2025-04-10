using System.Collections;
using UnityEngine;

public class PerdePonto : MonoBehaviour
{
    [SerializeField] GameObject texto;

    void Start()
    {
        StartCoroutine(Perde());
    }

    IEnumerator Perde()
    {
        while (true)
        {
            Pontuacao.pontos -= 5;
            StartCoroutine(ApareceEdesa());
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator ApareceEdesa()
    {
        texto.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        texto.SetActive(false);
    }
}
