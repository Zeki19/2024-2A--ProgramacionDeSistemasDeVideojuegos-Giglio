using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;


public interface IUnitFactory
{
    GameObject CreateUnit(Faction faction, UnitClass unitClass);
}
