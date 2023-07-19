using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienController : MonoBehaviour
{
    [SerializeField]
    private DeathType[] _arrayMuertes;

    [SerializeField]
    private DeathType _deathType;


    private bool _alive = true;
    private Animator _animator;

    public bool Alive { get; }


    private float _remainingTime;

    private Slider _slider;

    public Vector3 _text_offset;

    [SerializeField]
    private SelectText _selectText;

    [SerializeField]
    private Image _selectImage;


    private void Awake()
    {
        int val = Random.Range(0, _arrayMuertes.Length);
        _deathType = _arrayMuertes[val];
        _selectText = gameObject.GetComponentInChildren<SelectText>();
        _selectText.deathType = _deathType;
    }

    // Start is called before the first frame update
    void Start()
    {
        

        _remainingTime =_deathType.death_timer;

        _animator = gameObject.GetComponent<Animator>();
        _slider = gameObject.GetComponentInChildren<Slider>();


        StartCoroutine(StartDeathTimer());



    }

    void Update() {
        _remainingTime -= Time.deltaTime;
      
        _slider.value = _remainingTime/_deathType.death_timer*100;

        _selectText.transform.SetPositionAndRotation(this.transform.position + _text_offset, Quaternion.LookRotation(Vector3.down));
        _selectImage.transform.SetPositionAndRotation(this.transform.position + _text_offset, Quaternion.LookRotation(Vector3.down));
    }

    IEnumerator StartDeathTimer()
    {
        yield return new WaitForSeconds(_deathType.death_timer);
        _alive = false;

        _animator.SetBool("Alive", _alive);
        Destroy(this);
        Debug.Log("Alien ha muerto");
    }
}
