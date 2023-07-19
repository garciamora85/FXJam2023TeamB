using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SelectText : MonoBehaviour
{
    private int NumeroFrase;

    public DeathType deathType;

    private String frase;

    private TextMeshProUGUI texto;

    private static float TiempoEntreLetras = 0.07f;

    private float tiempoEspera = 8f;
    private float tiempoTranscurrido = 0f;

    private AlienController _alienController;

    private Coroutine _corroutine;


    public void OnEnable()
    {
        EventBus.Subscribe(EventBus.AlienEventType.PICKED, AnotherAlienPicked);
        EventBus.Subscribe(EventBus.AlienEventType.DROPPED, CambiarFrase);
    }

    public void OnDisable()
    {
        EventBus.Unsubscribe(EventBus.AlienEventType.PICKED, AnotherAlienPicked);
        EventBus.Unsubscribe(EventBus.AlienEventType.DROPPED, CambiarFrase);
    }


    // Start is called before the first frame update
    void Start()
    {
        _alienController = GetComponentInParent<AlienController>();
        CambiarFrase();
    }

    public void FixedUpdate()
    {
        tiempoTranscurrido += Time.fixedDeltaTime;
    }

    public void AnotherAlienPicked()
    {
        int val = UnityEngine.Random.Range(0, 2);
        int n = 15 + val;

        texto = gameObject.GetComponent<TextMeshProUGUI>();

        frase = Frases.GetFrase(n);
        //Play hurt sound from alien
        _alienController.PlayHurt();

        StartCoroutine(escribir());
    }

    public void Picked()
    {
        EventBus.Unsubscribe(EventBus.AlienEventType.PICKED, AnotherAlienPicked);
        EventBus.Unsubscribe(EventBus.AlienEventType.DROPPED, CambiarFrase);
        EventBus.Publish(EventBus.AlienEventType.PICKED);
    }

    public void Dropped()
    {
        EventBus.Publish(EventBus.AlienEventType.DROPPED);
    }


    public void CambiarFrase()
    {
        int val = UnityEngine.Random.Range(0, 2);
        int n = (deathType.death_identifyer * 3) + val;

        texto = gameObject.GetComponent<TextMeshProUGUI>();

        frase = Frases.GetFrase(n);
        //Play hurt sound from alien
        _alienController.PlayHurt();


        if(_corroutine!=null)
            StopCoroutine(_corroutine);

        _corroutine = StartCoroutine(escribir());
    }

    IEnumerator escribir()
    {
        texto.text = "";
        for (int i = 0; i < frase.Length; i++)
        {
            texto.text += frase[i];

            //Necesario para que se actualice el tamaño del cuadro de texto
            Canvas.ForceUpdateCanvases();
            transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
            transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;

            yield return new WaitForSeconds(TiempoEntreLetras);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && tiempoTranscurrido > tiempoEspera) {
            tiempoTranscurrido = 0f;
            CambiarFrase();
        }
    }
}
