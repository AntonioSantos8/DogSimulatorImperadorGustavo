using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public GameObject[] navMeshDestination;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(NavDest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination"))
        {

        }
    }
    
    IEnumerator NavDest()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        int randomIndex = Random.Range(0, navMeshDestination.Length);
        
        for (int i = 0; i < navMeshDestination.Length; i++)
        {
            if(i == randomIndex)
            {
                agent.SetDestination(navMeshDestination[i].transform.position);
            }
        }

        yield return new WaitForSeconds(1);
    }
    IEnumerator NextAction()
    {
        yield return new WaitForSeconds(10);

    }
}
