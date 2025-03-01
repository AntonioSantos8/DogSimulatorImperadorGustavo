using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MontarSushi : MonoBehaviour
{
    [Header("Orders")]
    public GameObject[] npcList; 
    public Dictionary<GameObject, string> npcPedidos = new Dictionary<GameObject, string>();
    public string pedidoAtual;
    private GameObject npcAlvo; 

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
    public GameObject[] uiPedidos;
    bool canTalkNpc;
    bool canInteractTrash;
    [Header("NpcSpawn")]
    public GameObject npcSpawn;
    public GameObject[] npc;
    public static MontarSushi montaSushi;
    public List<GameObject> mesas;
    string[] npcPedido;
 

    public int numeroDeNpc;
    public GameObject naoFez;
    public bool pedidoEntregue = false;
    public GameObject otherDest;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NpcSpawn());
    }
    public void Awake()
    {
        montaSushi = this;
    }
    public static List<GameObject> getTables()
    {
        return montaSushi.mesas;
    }
    public static GameObject getOtherDest()
    {
        return montaSushi.otherDest;
    }
    // Update is called once per frame
    void Update()
    {
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
            GerarPedidoParaNpc(npcAlvo);
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
        if (other.CompareTag("NpcTalk"))
        {
            npcAlvo = other.gameObject; 
            canTalkNpc = true;
        }
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
        if (other.CompareTag("NpcTalk"))
        {
            npcAlvo = other.gameObject; 
            canTalkNpc = false;
        }
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
    public void GerarPedidoParaNpc(GameObject npc)
    {
        string[] possiveisPedidos = { "didRice_Salmao_Seaweed", "didRice_Seaweed_CreamCheese", "didSalmao_Rice_Creamcheese", "didSalmao_CreamCheese" };
        string pedidoAleatorio = possiveisPedidos[Random.Range(0, possiveisPedidos.Length)];

        if (!npcPedidos.ContainsKey(npc))
        {
            npcPedidos.Add(npc, pedidoAleatorio);
        }
        else
        {
            npcPedidos[npc] = pedidoAleatorio;
        }

        Debug.Log($"NPC {npc.name} pediu: {pedidoAleatorio}");
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
        if (pedidoAtual == "didRice_Salmao_Seaweed")
        {
            uiPedidos[0].SetActive(true);
           
        }
        if (pedidoAtual == "didRice_Seaweed_CreamCheese")
        {
            uiPedidos[1].SetActive(true);
            
        }
        if (pedidoAtual == "didSalmao_Rice_Creamcheese")
        {
            uiPedidos[2].SetActive(true);
            
        }
        if (pedidoAtual == "didSalmao_CreamCheese")
        {
            uiPedidos[3].SetActive(true);
           
        }
        
    }
    
    public void EntregarProCliente()
    {
        if (npcAlvo == null || !npcPedidos.ContainsKey(npcAlvo))
        {
            Debug.Log("Nenhum NPC encontrado ou NPC não tem pedido.");
            return;
        }

        string pedidoDoNpc = npcPedidos[npcAlvo];

        if (pedidoAtual == pedidoDoNpc)
        {
            Debug.Log($"Pedido entregue corretamente para {npcAlvo.name}!");
            npcPedidos.Remove(npcAlvo);
            pedidoAtual = "";
        }
        else
        {
            Debug.Log($"Este não é o pedido correto para {npcAlvo.name}. Ele queria {pedidoDoNpc}.");
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
