using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int max_time;

    private void Start()
    {
       
    }

    public void SetMaxTime(float val) {
        slider.maxValue = max_time;
    }

    public void SetHealth( float val ) {

        slider.value = val;
    }
}
