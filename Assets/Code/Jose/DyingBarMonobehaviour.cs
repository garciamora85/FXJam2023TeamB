using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingBarMonobehaviour : MonoBehaviour
{

    public float timer = 0.0f;
    public float death_time = 10.0f;
    public GameObject healthbar_prefab;
    public Vector3 offset;

    private HealthBar hbc;

    void Awake()
    {
        if (!healthbar_prefab)
        {
            Instantiate(healthbar_prefab, offset + gameObject.transform.position, Quaternion.identity);
            hbc = healthbar_prefab.GetComponent<HealthBar>();
            int dt = GetComponentInParent<DeathTypeBehaviour>().dying_type.death_timer;
            hbc.SetMaxTime(dt);
            hbc.SetHealth(dt);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (timer > death_time) {
            hbc.SetHealth(death_time);
            death_time -= Time.deltaTime;
        }
    }


}
