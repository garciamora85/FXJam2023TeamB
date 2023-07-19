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

    public bool Alive { get { return _alive; } }


    private float _remainingTime;

    private Slider _slider;

    public Vector3 _text_offset;

    [SerializeField]
    private SelectText _selectText;

    [SerializeField]
    private Image _selectImage;

    public AudioSource _alienSource;

    public AudioClip _hurtClip;
    public AudioClip _dieClip;
    public AudioClip _safeClip;

    private Coroutine _corroutine;

    private void Awake()
    {
        int val = Random.Range(0, _arrayMuertes.Length);
        _deathType = _arrayMuertes[val];
        _selectText = gameObject.GetComponentInChildren<SelectText>();
        _alienSource = gameObject.GetComponent<AudioSource>();
        _selectText.deathType = _deathType;
    }

    // Start is called before the first frame update
    void Start()
    {
        _remainingTime =_deathType.death_timer;

        _animator = gameObject.GetComponent<Animator>();
        _slider = gameObject.GetComponentInChildren<Slider>();

        _corroutine = StartCoroutine(StartDeathTimer());
    }

    void Update() {
        _remainingTime -= Time.deltaTime;
      
        _slider.value = _remainingTime/_deathType.death_timer*100;

        _selectText.transform.SetPositionAndRotation(this.transform.position + _text_offset, Quaternion.LookRotation(Vector3.down));
        _selectImage.transform.SetPositionAndRotation(this.transform.position + _text_offset, Quaternion.LookRotation(Vector3.down));
    }

    public void PlayHurt() {
        //Play hurt sound from alien
        _alienSource.PlayOneShot(_hurtClip);
    }

    public void PlayDead()
    {
        //Play hurt sound from alien
        _alienSource.PlayOneShot(_dieClip);
    }

    public void PlaySafe()
    {
        //Play hurt sound from alien
        _alienSource.PlayOneShot(_safeClip);
    }

    public void DisableText() {
        _selectText.enabled = false;
        _selectImage.enabled = false;
        Canvas[] components = this.GetComponentsInChildren<Canvas>();
        foreach(Canvas comp in components) {
            //comp.gameObject.SetActive(false);
            comp.enabled = false;
        }
    }

    IEnumerator StartDeathTimer()
    {
        yield return new WaitForSeconds(_deathType.death_timer);
        _alive = false;
        _animator.SetBool("Alive", _alive);
        PlayDead();
        DisableText();
        this.enabled = false;
        //Debug.Log("Alien ha muerto");
    }

    public void StopDeath()
    {
        StopCoroutine(_corroutine);
    }

}
