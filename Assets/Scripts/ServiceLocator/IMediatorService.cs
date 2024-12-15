using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public interface IMediatorService
{
    public Arrow GetArrow();
    public void SpawnUnit(UnitClass unitClass, bool isEnemy, Vector3? spawnPosition = null);
}
