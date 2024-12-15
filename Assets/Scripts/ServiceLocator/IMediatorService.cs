using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public interface IMediatorService
{
    public Arrow GetArrow();
    public IAbility GetAbility(string name);
    public void SpawnUnit(UnitClass unitClass, bool isEnemy, Vector3? spawnPosition = null);
}
