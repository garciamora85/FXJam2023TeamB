using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{

    private bool _alive = true;
    private Animator _animator;

    public bool Alive { get; }

    [SerializeField]
    private float LifeTime;


    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        StartCoroutine(StartDeathTimer());
    }

    IEnumerator StartDeathTimer()
    {
        yield return new WaitForSeconds(LifeTime);
        _alive = false;

        _animator.SetBool("Alive", _alive);
        Debug.Log("Alien ha muerto");
    }
}
