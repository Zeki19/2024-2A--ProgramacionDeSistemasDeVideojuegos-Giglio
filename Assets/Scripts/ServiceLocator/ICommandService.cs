using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public interface ICommandService
{
    public void SpawnUnit(Units.UnitClass unitClass, bool isEnemy, int amount, [CanBeNull] Transform pos);
    public void MessageBox(string message);
}
