using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseDesafiadora : MonoBehaviour
{
    public int quantQuePrecisa;
    int tempoPraAcaba = 6;
    public TMP_Text tempoPraAcabaTXT;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LimiteDeTempo());
    }

    // Update is called once per frame
    void Update()
    {
        if(quantQuePrecisa == 10)
        {
            Pontuacao.pontos += 100;
            PlayerPrefs.SetInt("Points", Pontuacao.pontos);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EasyMode");
        }
    }
    IEnumerator LimiteDeTempo()
    {
        while (tempoPraAcaba >= 0)
        {

            yield return new WaitForSeconds(1);
            tempoPraAcaba--;
            tempoPraAcabaTXT.text = "Tempo: " + tempoPraAcaba.ToString();
        }
        

        SceneManager.LoadScene("EasyMode");

    }
}
