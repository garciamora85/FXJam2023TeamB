using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Temporizador : MonoBehaviour
{
    public float time, timeEnd, timeMax;
    public Text text;
    public Animator anim;

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
            timeEnd = timeEnd + Time.deltaTime;
            anim.SetBool("end", true);
            if (timeEnd >= timeMax)
            {
                SceneManager.LoadScene("Final");
            }
            Debug.Log("Se acabo el tiempo");
        }
        
    }
}
