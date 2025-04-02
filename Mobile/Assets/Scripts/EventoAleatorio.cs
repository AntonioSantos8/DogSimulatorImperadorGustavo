using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoAleatorio : MonoBehaviour
{
    public GameObject[] buttonsPreto;
    public GameObject[] buttonsRainbow;
    GameObject buttonToApear;
    GameObject buttonToApearRainbow;
    bool eventStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pontuacao.startou && !eventStarted)
        {
            eventStarted = true;
            StartCoroutine(EventoAleat());
        }
    }
    void SorteiaBTNPreto()
    {
        
        buttonToApear = buttonsPreto[Random.Range(0, buttonsPreto.Length)];
        StartCoroutine(AtivaEdesativaBTN(buttonToApear));
        
    }
    void SorteiaBTNRainbow()
    {
        buttonToApearRainbow = buttonsRainbow[Random.Range(0, buttonsRainbow.Length)];
    }
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator AtivaEdesativaBTN(GameObject btnToDesactive)
    {
        btnToDesactive.SetActive(true);
        yield return new WaitForSeconds(1);
        btnToDesactive.SetActive(false);
    }

    IEnumerator EventoAleat()
    {
        int time = Random.Range(0, 30);
        yield return new WaitForSeconds(time);
        SorteiaBTNPreto();
        StartCoroutine(EventoAleatorioArcoIris());
        Pontuacao.startou = false;
        StartCoroutine(EventoAleat());
    }
    IEnumerator EventoAleatorioArcoIris()
    {
        int chance = Random.Range(1, 5);
        yield return new WaitForSeconds(1);
        if(chance == 1)
        {
            SorteiaBTNRainbow();
        }
    }
}
