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
    int pontos;
    public void ClickToStart(GameObject btnToStart)
    {
        Sorteia(btnToStart);
        proxBtn = btnToStart;

    }
    private void Update()
    {
        if(pontos >= 20)
        {
            SceneManager.LoadScene("EasyMode");
        }
        texto.text = pontos.ToString();
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
        pontos++;
    }
}
