using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PunctuationScript : MonoBehaviour
{
    public bool type;
    private GameManager gm;
    private TextMeshProUGUI my_text;
    private int value = 999;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        my_text = GetComponent<TextMeshProUGUI>();

        if (type)
        {
            value = gm.saved;
        }
        else {
            value = gm.dead;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (value != gm.max)
        {
            my_text.text = value.ToString();
        }
        else if (value == 0)
        { my_text.text = "NO ONE!"; }
        else
        { my_text.text = "EVERYONE!"; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu()
    {
        gm.DestroyGameManager();
        SceneManager.LoadScene("Creditos");


    }
}
