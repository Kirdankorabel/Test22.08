using System;
using UnityEngine;

public interface IReleaser
{
    public event Action<Vector3> CellReleased;
    public event Action<IReleaser> Destroyed;
}