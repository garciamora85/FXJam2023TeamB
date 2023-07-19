using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateDeathType", order = 1)]
public class DeathType : ScriptableObject
{
    public int death_identifyer;
    public float death_timer;
    public string death_name;
    public Material death_material;
    //public Animation death_animation;
}
