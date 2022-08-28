using System;
using UnityEngine;

[Serializable]
public class SettingsInfo
{
    [SerializeField] public float musicVolume;
    [SerializeField] public float soundVolume;

    public SettingsInfo() { }
}