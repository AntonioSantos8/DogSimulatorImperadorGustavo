using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RainbowPhase : MonoBehaviour
{
    [SerializeField] GameObject startBTN;
    public GameObject[] buttons;
    public TMP_Text texto;
    GameObject buttonToApear;
    GameObject proxBtn;
    int pontus;
    bool faseTerminou;
    int tempoPraAcaba = 8;
    public TMP_Text tempoPraAcabaTXT;
    public void ClickToStart(GameObject btnToStart)
    {
        Sorteia(btnToStart);
        proxBtn = btnToStart;

    }
    private void Start()
    {
        tempoPraAcabaTXT.text = "Tempo: " + tempoPraAcaba.ToString();

        if (PlayerPrefs.HasKey("Points"))
        {
            Pontuacao.pontos = PlayerPrefs.GetInt("Points");
        }
        StartCoroutine(LimiteDeTempo());
    }
    private void Update()
    {
        PlayerPrefs.SetInt("Points", Pontuacao.pontos);
        if (pontus >= 100 && !faseTerminou)
        {
            faseTerminou = true;
            StartCoroutine(TrocarDeFase());
        }
        texto.text = pontus.ToString();
    }
    void Sorteia(GameObject btnToStart)
    {
        do
        {
            buttonToApear = buttons[Random.Range(0, buttons.Length)];
        }
        while (buttonToApear == btnToStart);
        buttonToApear.SetActive(true);

        btnToStart.SetActive(false);


        pontus += 5;
    }
    IEnumerator TrocarDeFase()
    {
        Pontuacao.pontos += pontus;
        PlayerPrefs.SetInt("Points", Pontuacao.pontos);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("EasyMode");
    }
    IEnumerator LimiteDeTempo()
    {
        while (tempoPraAcaba >= 0)
        {

            yield return new WaitForSeconds(1);
            tempoPraAcaba--;
            tempoPraAcabaTXT.text = "Tempo: " + tempoPraAcaba.ToString();
        }
        Pontuacao.pontos += pontus;
        PlayerPrefs.SetInt("Points", Pontuacao.pontos);
        PlayerPrefs.Save();

        SceneManager.LoadScene("EasyMode");

    }
}
