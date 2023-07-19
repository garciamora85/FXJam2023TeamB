using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int NumeroEnemigos;

    [SerializeField]
    private List<GameObject> Spawns;


    GameObject _prefabAlien;


    private void Awake()
    {
        _prefabAlien = (GameObject)Resources.Load("Prefabs/Alien");

        for(int i=0; i<NumeroEnemigos; i++)
        {
            int n = Random.Range(0, Spawns.Count);

            GameObject gameObject = Spawns[n];
            Spawns.RemoveAt(n);

            Instantiate(_prefabAlien, gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        }
    }

}