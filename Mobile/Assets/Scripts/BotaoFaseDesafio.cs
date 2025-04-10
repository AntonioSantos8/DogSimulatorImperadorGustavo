using UnityEngine;
using UnityEngine.UI;

public class BotaoFaseDesafio : MonoBehaviour
{
    FaseDesafiadora faseDesafiadora;

    void Start()
    {

        faseDesafiadora = FindObjectOfType<FaseDesafiadora>();
        Button btn = GetComponent<Button>();

        if (btn != null)
        {
            btn.onClick.AddListener(DestroyThis);
        }
    }
    void DestroyThis()
    {
        faseDesafiadora.quantQuePrecisa++;
        Destroy(gameObject);
    }
}
