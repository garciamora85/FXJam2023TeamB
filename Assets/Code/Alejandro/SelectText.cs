using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectText : MonoBehaviour
{
    [SerializeField]
    private int NumeroFrase;

    [SerializeField]
    private GameObject img;


    private TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        texto = gameObject.GetComponent<TextMeshProUGUI>();

        texto.text = Frases.GetFrase(NumeroFrase);
    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "cambiar frase"))
        {
            texto = gameObject.GetComponent<TextMeshProUGUI>();
            
            texto.text = Frases.GetFrase(1);


            //Necesario para que se actualice el tamaño del cuadro de texto
            Canvas.ForceUpdateCanvases();
            transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
            transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
        }
    }

}
