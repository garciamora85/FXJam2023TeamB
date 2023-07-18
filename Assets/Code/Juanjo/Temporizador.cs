using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Temporizador : MonoBehaviour
{
    public float time;
    public Text text;

    private void Update()
    {
        text.text = time.ToString("00:00");
        if (time > 0)
        {
            time = time - Time.deltaTime;
            
        }
        else
        {
            time = 0;
            
            Debug.Log("Se acabo el tiempo");
        }
        
    }
}
