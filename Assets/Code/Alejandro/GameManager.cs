using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private float time = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator StartTimer()
    {

        yield return new WaitForSeconds(time);
        EndGame();

    }

    void EndGame()
    {
        //pasar puntuaciones al playerdata


        //pasar a escena de créditos
        SceneManager.LoadScene("Final");
       



    }


}
