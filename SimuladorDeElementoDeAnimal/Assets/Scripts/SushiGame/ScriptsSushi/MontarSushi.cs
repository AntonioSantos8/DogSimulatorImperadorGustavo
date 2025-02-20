using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MontarSushi : MonoBehaviour
{
    [Header("Refrigerator")]
    bool canOpenRefrigerator;
    bool refrigeratorIsOpen;
    [Space]
    public GameObject refrigeratorPanel;
    public GameObject[] refrigeratorIngredients;

    [Header("Shelve")]
    bool canOpenShelve;
    bool shelveIsOpen;
    [Space]
    public GameObject shelvePanel;
    public GameObject[] shelveIngredients;

    [Header("Orders")]
    GameObject[] oorder;

    [Header("MesaDePreparo")]
    bool isTouchingMesaDePreparo;
    string handItem;
    [Space]
    bool putRice;
    bool putSalmon;
    bool putSeaweed;
    bool putCreamcheese;
    [Space]
    bool didRice_Salmao_Seaweed;
    bool didRice_Seaweed_CreamCheese;
    bool didSalmao_Rice_Creamcheese;
    bool didSalmao_CreamCheese;
    [Space]
    public GameObject[] sushiDiddy;
    public string[] receba2;
    public string pedidoLegal;
    public GameObject[] uiPedidos;
    bool canTalkNpc;
    bool canInteractTrash;
    [Header("NpcSpawn")]
    public GameObject npcSpawn;
    public GameObject[] npc;
    public static MontarSushi montaSushi;
    public GameObject[] mesas;
 
    public int numeroDeNpc;
    public GameObject naoFez;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NpcSpawn());
    }
    public void Awake()
    {
        montaSushi = this;
    }
    public static GameObject[] getTables()
    {
        return montaSushi.mesas;
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(pedidoLegal);
        if (canOpenRefrigerator && Input.GetKeyDown(KeyCode.E))
        {
            refrigeratorIsOpen = !refrigeratorIsOpen;
            refrigeratorPanel.SetActive(refrigeratorIsOpen);
            if (refrigeratorIsOpen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if (canOpenShelve && Input.GetKeyDown(KeyCode.E))
        {
            shelveIsOpen = !shelveIsOpen;
            shelvePanel.SetActive(shelveIsOpen);
            if (shelveIsOpen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if(isTouchingMesaDePreparo && Input.GetKeyDown(KeyCode.E))
        {
            PutIngredient();
        }
        Vericacao();
        Verificacao2();
        if(canTalkNpc &&  Input.GetKeyDown(KeyCode.E))
        {
            Order();
        }
        if (canTalkNpc && Input.GetKeyDown(KeyCode.E))
        {
            EntregarProCliente();
        }
        if(canInteractTrash && Input.GetKeyDown(KeyCode.E))
        {
            Trash();
            

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Refrigerator"))
        {
            canOpenRefrigerator = true;
          
        }
        if (other.CompareTag("Shelve"))
        {
            canOpenShelve = true;
           
        }
        if (other.CompareTag("MesaDePreparo"))
        {
            isTouchingMesaDePreparo = true;
            
        }
        if (other.CompareTag("NpcTalk"))
        {
            canTalkNpc = true;
            
        }
        if (other.CompareTag("Trash"))
        {
            canInteractTrash = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Refrigerator"))
        {
            canOpenRefrigerator = false;
            
        }
        if (other.CompareTag("Shelve"))
        {
            canOpenShelve = false;
            
        }
        if (other.CompareTag("NpcTalk"))
        {
            canTalkNpc = false;
           
        }
        if (other.CompareTag("Trash"))
        {
            canInteractTrash = false;

        }
    }
    public void RefrigeratorIngred(string type)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        refrigeratorIsOpen = !refrigeratorIsOpen;
        refrigeratorPanel.SetActive(refrigeratorIsOpen);
        switch (type)
        {
            case "Cola":
                refrigeratorIngredients[0].SetActive(true);
                break;
            case "Water":
                refrigeratorIngredients[1].SetActive(true);
                break;
            case "Juice":
                refrigeratorIngredients[2].SetActive(true);
                break;
            case "Beer":
                refrigeratorIngredients[3].SetActive(true);
                break;
        }    
    }
    public void ShelveIngred(string type)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shelveIsOpen = !shelveIsOpen;
        shelvePanel.SetActive(shelveIsOpen);
        switch (type)
        {
            case "Rice":
                shelveIngredients[0].SetActive(true);
                
                handItem = "Rice";
                break;
            case "Salmon":
                shelveIngredients[1].SetActive(true);
                
                handItem = "Salmon";
                break;
            case "Seaweed":
                shelveIngredients[2].SetActive(true);
                
                handItem = "Seaweed";
                break;
            case "CreamCheese":
                shelveIngredients[3].SetActive(true);

                handItem = "CreamCheese";
                break;

        }
        
    }
    void PutIngredient()
    {
        if(handItem == "Rice")
        {
            shelveIngredients[0].SetActive(false);
            putRice = true;
            handItem = "";
        }
        if(handItem == "Salmon")
        {
            shelveIngredients[1].SetActive(false);
            putSalmon = true;
            handItem = "";
        }
        if(handItem == "Seaweed")
        {
            shelveIngredients[2].SetActive(false);
            putSeaweed = true;
            handItem = "";
        }
        if(handItem == "CreamCheese")
        {
            shelveIngredients[3].SetActive(false);
            putCreamcheese = true;
            handItem = "";
        }
    }
    void Vericacao()
    {
        if(putRice && putSalmon && putSeaweed)
        {
            sushiDiddy[0].SetActive(true);
            didRice_Salmao_Seaweed = true;
         
        }
        if(putRice && putSeaweed &&  putCreamcheese)
        {
            sushiDiddy[1].SetActive(true);
            didRice_Seaweed_CreamCheese = true;
         

        }
        if (putSalmon && putRice && putCreamcheese)
        {
            sushiDiddy[2].SetActive(true);
            didSalmao_Rice_Creamcheese = true;
         
            
        }
       
        if (putSalmon && putCreamcheese)
        {
            sushiDiddy[3].SetActive(true);
            didSalmao_CreamCheese = true;
         
           

        }
        if (didSalmao_Rice_Creamcheese)
        {
            sushiDiddy[3].SetActive(false);
            didSalmao_CreamCheese = false;
        }
    }
    void Trash()
    {
        
        didRice_Salmao_Seaweed = false;
        didRice_Seaweed_CreamCheese = false;
        didSalmao_Rice_Creamcheese = false;
        didSalmao_CreamCheese = false;
        putSalmon = false;
        putCreamcheese = false;
        putRice = false;
        putSeaweed = false;

      
        
        sushiDiddy[0].SetActive(false);
        sushiDiddy[1].SetActive(false);
        sushiDiddy[2].SetActive(false);
        sushiDiddy[3].SetActive(false);
    }
    void Verificacao2()
    {
        if (pedidoLegal == "didRice_Salmao_Seaweed")
        {
            uiPedidos[0].SetActive(true);
           
        }
        if (pedidoLegal == "didRice_Seaweed_CreamCheese")
        {
            uiPedidos[1].SetActive(true);
            
        }
        if (pedidoLegal == "didSalmao_Rice_Creamcheese")
        {
            uiPedidos[2].SetActive(true);
            
        }
        if (pedidoLegal == "didSalmao_CreamCheese")
        {
            uiPedidos[3].SetActive(true);
           
        }
        
    }
    public void Order()
    {
        if (string.IsNullOrEmpty(pedidoLegal))
        {
            int randomIndex = Random.Range(0, receba2.Length);
            pedidoLegal = receba2[randomIndex];
        }
    }
    public void EntregarProCliente()
    {
        bool pedidoEntregue = false;

        if (pedidoLegal == "didRice_Salmao_Seaweed" && didRice_Salmao_Seaweed)
        {
            uiPedidos[0].SetActive(false);
            sushiDiddy[0].SetActive(false);
            pedidoEntregue = true;
        }
        else if (pedidoLegal == "didRice_Seaweed_CreamCheese" && didRice_Seaweed_CreamCheese)
        {
            uiPedidos[1].SetActive(false);
            sushiDiddy[1].SetActive(false);
            pedidoEntregue = true;
        }
        else if (pedidoLegal == "didSalmao_Rice_Creamcheese" && didSalmao_Rice_Creamcheese)
        {
            uiPedidos[2].SetActive(false);
            sushiDiddy[2].SetActive(false);
            pedidoEntregue = true;
        }
        else if (pedidoLegal == "didSalmao_CreamCheese" && didSalmao_CreamCheese)
        {
            uiPedidos[3].SetActive(false);
            sushiDiddy[3].SetActive(false);
            pedidoEntregue = true;
        }

        if (pedidoEntregue)
        {
            pedidoLegal = "";
 
            didRice_Salmao_Seaweed = false;
            didRice_Seaweed_CreamCheese = false;
            didSalmao_Rice_Creamcheese = false;
            didSalmao_CreamCheese = false;
            putSalmon = false;
            putCreamcheese = false;
            putRice = false;
            putSeaweed = false;
        }
        else
        {
            
        }
    }

    IEnumerator NpcSpawn()
    {
       
        yield return new WaitForSeconds(5);
        
        while (numeroDeNpc < 3)
        {
            Instantiate(npc[Random.Range(0, npc.Length)], npcSpawn.transform.position, npcSpawn.transform.rotation);
            numeroDeNpc += 1;
            yield return new WaitForSeconds(3);
        }
     
        StartCoroutine(NpcSpawn());
    }
    IEnumerator AparecerEdesaparecer(GameObject vaiAparecerEdesaparecer)
    {
        vaiAparecerEdesaparecer.SetActive(true);
        yield return new WaitForSeconds(3);
        vaiAparecerEdesaparecer.SetActive(false);
    }
    
    //diminuir n quando npc sai da loja
}
