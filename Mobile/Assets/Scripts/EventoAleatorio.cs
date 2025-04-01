using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoAleatorio : MonoBehaviour
{
    public GameObject[] buttons;
    GameObject buttonToApear;
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
    void Sorteia()
    {
        
        buttonToApear = buttons[Random.Range(0, buttons.Length)];
        buttonToApear.SetActive(true);

    }
    public void NextScene()
    {
        SceneManager.LoadScene("FaseDark");
    }
    IEnumerator EventoAleat()
    {
        int time = Random.Range(0, 60);
        yield return new WaitForSeconds(time);
        Sorteia();
        Pontuacao.startou = false;
    }
}
