using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CollumInfo
{
    [SerializeField] public List<ItemInfo> ItemInfos;
    [SerializeField] public int Position;

    public CollumInfo () { }
}