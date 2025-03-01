using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public List<GameObject> navMeshDestination;
    MontarSushi montarSushi;

   
    
    // Start is called before the first frame update
    void Start()
    {
        montarSushi = FindObjectOfType<MontarSushi>();
        StartCoroutine(NavDest());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (montarSushi.pedidoEntregue)
        {
            NextAction();
        }
    }
   
    IEnumerator NavDest()
    {
        navMeshDestination = MontarSushi.getTables();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        int randomIndex = Random.Range(0, navMeshDestination.Count);
        
        for (int i = 0; i < navMeshDestination.Count; i++)
        {
            if(i == randomIndex)
            {
                agent.SetDestination(navMeshDestination[i].transform.position);
            }
            

        }

        montarSushi.mesas.Remove(navMeshDestination[randomIndex]);
        yield return new WaitForSeconds(1);
    }
    void Verifica3()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        montarSushi.mesas.Add(montarSushi.otherDest);
    }
    IEnumerator NextAction()
    {
        yield return new WaitForSeconds(5);
        Verifica3();
       
    }
}
