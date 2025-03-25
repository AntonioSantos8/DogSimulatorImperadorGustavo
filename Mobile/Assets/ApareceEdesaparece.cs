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
        texto.text = Pontuacao.pontos.ToString();
    }
    public void ClickToStart(GameObject btnToStart)
    {
        do
        {
            buttonToApear = buttons[Random.Range(0, buttons.Length)];
        }
        while (buttonToApear == btnToStart);

        buttonToApear.SetActive(true);
        
        btnToStart.SetActive(false);
        Pontuacao.pontos++;
        
    }
    
   
}
public static class Pontuacao
{
    public static int pontos;
}