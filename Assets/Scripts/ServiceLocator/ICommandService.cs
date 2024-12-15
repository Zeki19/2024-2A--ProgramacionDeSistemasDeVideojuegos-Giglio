using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandService
{
    public void SpawnUnit(Units.UnitClass unitClass, bool isEnemy, int amount);
}
