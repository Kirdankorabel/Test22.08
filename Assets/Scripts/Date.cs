using System;
using UnityEngine;

[Serializable]
public class Date
{
    [SerializeReference] public VertPanelInfo VerticalPanelInfo;
    [SerializeReference] public SettingsInfo AudioSettingsinfo;

    public Date () { }
}