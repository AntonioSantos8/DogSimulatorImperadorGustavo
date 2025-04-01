using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PontuacaoVerify : MonoBehaviour
{
    public AudioClip holyWars;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Pontuacao.pontos >= 100)
        {
            if (!source.isPlaying)
            {
                source.clip = holyWars;
                source.Play();
            }
        }
    }
}
