using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkPhase : MonoBehaviour
{
    [SerializeField] GameObject startBTN;
    public GameObject[] buttons;
    public TMP_Text texto;
    GameObject buttonToApear;
    GameObject proxBtn;
    int pontus;
    
    public void ClickToStart(GameObject btnToStart)
    {
        Sorteia(btnToStart);
        proxBtn = btnToStart;

    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("Points"))
        {
            Pontuacao.pontos = PlayerPrefs.GetInt("Points");
        }
    }
    private void Update()
    {
        PlayerPrefs.SetInt("Points", Pontuacao.pontos);
        if (pontus >= 20)
        {
            

            SceneManager.LoadScene("EasyMode");
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
        Pontuacao.pontos += 20;
 
        pontus += 2;
    }
}
