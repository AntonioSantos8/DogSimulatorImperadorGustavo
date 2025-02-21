using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesas : MonoBehaviour
{
    MontarSushi aa;
    // Start is called before the first frame update
    void Start()
    {
        aa = FindObjectOfType<MontarSushi>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            aa.mesas.Add(gameObject);
        }
    }

}
