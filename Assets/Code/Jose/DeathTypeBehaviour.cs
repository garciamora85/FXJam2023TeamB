using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTypeBehaviour : MonoBehaviour
{
    public DeathType dying_type;
    

    void Awake()
    {
        DeathType[] array = Resources.FindObjectsOfTypeAll<DeathType>();
        int val = Random.Range(0, array.Length);

        dying_type = array[val];
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
