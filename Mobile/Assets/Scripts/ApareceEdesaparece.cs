using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class ApareceEdesaparece : MonoBehaviour
{
    [SerializeField] GameObject startBTN;
    public GameObject[] buttons;
    public TMP_Text texto;
    GameObject buttonToApear;
    GameObject proxBtn;
    public GameObject pontoQueGanho;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Points"))
        {
            Pontuacao.pontos = PlayerPrefs.GetInt("Points");
        }
    }
    private void Update()
    {
       
        texto.text = Pontuacao.pontos.ToString();
    }
    public void ClickToStart(GameObject btnToStart)
    {
        Sorteia(btnToStart);
        proxBtn = btnToStart;
        Pontuacao.startou = true;
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
        Pontuacao.pontos++;
        PlayerPrefs.SetInt("Points", Pontuacao.pontos);
        StartCoroutine(ApareceEdesa());
    }
    IEnumerator ApareceEdesa()
    {
        pontoQueGanho.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        pontoQueGanho.SetActive(false);
    }
}
public static class Pontuacao
{
    public static int pontos;
    public static bool startou;
}