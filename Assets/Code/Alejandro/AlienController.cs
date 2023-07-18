using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienController : MonoBehaviour
{

    private bool _alive = true;
    private Animator _animator;

    public bool Alive { get; }

    [SerializeField]
    private float LifeTime;

    private float _remainingTime;

    private Slider _slider;


    public void SetLifeTime(float time)
    {
        LifeTime = time;
    }

    // Start is called before the first frame update
    void Start()
    {
        _remainingTime = LifeTime;

        _animator = gameObject.GetComponent<Animator>();
        _slider = gameObject.GetComponentInChildren<Slider>();

        StartCoroutine(StartDeathTimer());
    }

    void Update() {
        _remainingTime -= Time.deltaTime;
      
        _slider.value = _remainingTime/LifeTime*100;

    }



    IEnumerator StartDeathTimer()
    {
        yield return new WaitForSeconds(LifeTime);
        _alive = false;

        _animator.SetBool("Alive", _alive);
        Destroy(this);
        Debug.Log("Alien ha muerto");
    }
}
