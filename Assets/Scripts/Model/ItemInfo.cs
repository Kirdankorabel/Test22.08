using System;
using UnityEngine;

[Serializable]
public class ItemInfo
{
    [SerializeField] public string ImageName;

    public ItemInfo(string imName)
    {
        ImageName = imName;
    }

    public ItemInfo() { }
}