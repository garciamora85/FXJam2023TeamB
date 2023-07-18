using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    public Transform point;
    GameObject picked;
    public GameObject[] camillas;
    int n;
    bool full = false;

    private void Start()
    {
        n = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (full == false && other.tag == "Alien")
        {
            other.transform.SetParent(point);
            other.transform.position = point.transform.position;
            full = true;
            other.GetComponent<SphereCollider>().enabled = false;
            picked = other.gameObject;
        }
        if (full && other.tag == "Goal")
        {
            picked.transform.parent = null;
            picked.transform.position = camillas[n].transform.position;
            n++;
            full = false;
        }
        
    }
}
