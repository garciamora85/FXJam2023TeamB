using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private float time = 5;
    // Start is called before the first frame update

    private AlienController[] aliens;
    public int max, saved, dead = 0;
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartTimer());
        aliens = FindObjectsOfType<AlienController>();

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
        saved = 0;
        dead = 0;

        max = aliens.Length;
        //pasar puntuaciones al playerdata
        foreach (AlienController alien in aliens) {

            if (alien.Alive) ++saved;
            else ++dead;

        }

        //pasar a escena de créditos
        SceneManager.LoadScene("Final");
        //dead_text = GameObject.FindWithTag("dead_text").GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        //alive_text = GameObject.FindWithTag("alive_text").GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;

        //alive_text.text = "You Saved : " + saved + " Aliens";
        //dead_text.text = "You left behind : " + dead + " Aliens";

        //Destroy(gameObject);
    }

    public void DestroyGameManager() {
        Destroy(gameObject);
    }

    public void GoToMenu() {
        DestroyGameManager();
        SceneManager.LoadScene("Intro");


    }
}
