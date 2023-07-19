using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource background_music;
    public AudioSource alarm_1;
    public AudioSource alarm_2;
    public AudioSource alarm_3;

    public Temporizador tmp;

    public float percentage_1 = 0.75f, percentage_2 = 0.5f, percentage_3 = 0.25f;
    private float seventy, mid, quarter;
    private bool stereo_float_1, sf2, sf3 = false;
    // Start is called before the first frame update
    void Start()
    {

        seventy = tmp.time * percentage_1;
        mid = tmp.time * percentage_2;
        quarter = tmp.time * percentage_3;

        background_music.Play();
        alarm_1.Stop();
        alarm_2.Stop();
        alarm_3.Stop();

        if (tmp)
        {
            StartCoroutine(StartAlarm1());
            StartCoroutine(StartAlarm2());
            StartCoroutine(StartAlarm3());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stereo_float_1) {

            if (sf2) alarm_2.panStereo = Mathf.Sin(Time.time);
            if (sf3) alarm_3.panStereo = Mathf.Cos(Time.time);
        }
    }


    IEnumerator StartAlarm1()
    {
        yield return new WaitForSeconds(quarter);
        alarm_1.Play();
        stereo_float_1 = true;
    }
    IEnumerator StartAlarm2()
    {
        yield return new WaitForSeconds(mid);
        alarm_2.Play();
        sf2 = true;
    }
    IEnumerator StartAlarm3()
    {
        yield return new WaitForSeconds(seventy);
        alarm_3.Play();
        sf3 = true;
        background_music.pitch = 2.0f;
    }

}
