using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool riceB;
    bool seaweedB;
    bool salmonB;
    [Space]
    bool creamcheeseB;
    bool handItemB;
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
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Refrigerator"))
        {
            canOpenRefrigerator = true;
            Debug.Log("Encostou");
        }
        if (other.CompareTag("Shelve"))
        {
            canOpenShelve = true;
            Debug.Log("Encostou");
        }
        if (other.CompareTag("MesaDePreparo"))
        {
            isTouchingMesaDePreparo = true;
            Debug.Log("Encostou");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Refrigerator"))
        {
            canOpenRefrigerator = false;
            Debug.Log("Saiu");
        }
        if (other.CompareTag("Shelve"))
        {
            canOpenShelve = false;
            Debug.Log("Encostou");
        }
        if (other.CompareTag("MesaDePreparo"))
        {
            isTouchingMesaDePreparo = false;
            Debug.Log("Encostou");
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
                riceB = true;
                handItem = "Rice";
                break;
            case "Salmon":
                shelveIngredients[1].SetActive(true);
                salmonB = true;
                handItem = "Salmon";
                break;
            case "Seaweed":
                shelveIngredients[2].SetActive(true);
                seaweedB = true;
                handItem = "Seaweed";
                break;
            case "CreamCheese":
                shelveIngredients[3].SetActive(true);
                creamcheeseB = true;
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
        if(putSalmon && putRice && putCreamcheese)
        {
            sushiDiddy[2].SetActive(true);
            didSalmao_Rice_Creamcheese = true;
        }
        if(putSalmon && putCreamcheese)
        {
            sushiDiddy[3].SetActive(true);
            didSalmao_CreamCheese = true;
        }
    }
    public void Order()
    {
        int randomIndex = Random.Range(0, oorder.Length);
        for (int i = 0; i < oorder.Length; i++)
        {
            if(i == randomIndex)
            {
                oorder[i].SetActive(true);
            }
        }
    }
}
