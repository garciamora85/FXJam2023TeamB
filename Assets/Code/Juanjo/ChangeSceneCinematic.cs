using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneCinematic : MonoBehaviour
{
    public string texto;
    float time;
    public float timeMax;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time >= timeMax)
        {
            SceneManager.LoadScene(texto);
        }
    }
}
