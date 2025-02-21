using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public List<GameObject> navMeshDestination;
    MontarSushi montarSushi;
    [SerializeField] GameObject otherDest;
   
    
    // Start is called before the first frame update
    void Start()
    {
        montarSushi = FindObjectOfType<MontarSushi>();
        StartCoroutine(NavDest());
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    IEnumerator NextAction()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        yield return new WaitForSeconds(10);
        agent.SetDestination(otherDest.transform.position);
       
    }
}
