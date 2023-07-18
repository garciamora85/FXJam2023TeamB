using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateDeathType", order = 1)]
public class DeathType : ScriptableObject
{
    public int death_identifyer;
    public int death_timer;
    public string death_name;
    public Animation death_animation;
}
