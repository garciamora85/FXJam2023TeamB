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
    public AudioSource PickAndDropAudioSource;
    public AudioClip pick;
    public AudioClip drop;

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
            if (PickAndDropAudioSource && pick) PickAndDropAudioSource.PlayOneShot(pick);
            else Debug.LogError("NO AUDIO SOURCE IN PLAYER FOR THE PICK AND DROP");
            full = true;
            other.GetComponent<SphereCollider>().enabled = false;
            picked = other.gameObject;
            picked.GetComponentInChildren<BoxCollider>().enabled = false;
        }
        if (full && other.tag == "Goal")
        {
            picked.transform.parent = null;
            picked.transform.position = camillas[n].transform.position;
            n++;
            full = false;
            if (PickAndDropAudioSource && drop) PickAndDropAudioSource.PlayOneShot(drop);
            else Debug.LogError("NO AUDIO SOURCE IN PLAYER FOR THE PICK AND DROP");
        }
        
    }
}
