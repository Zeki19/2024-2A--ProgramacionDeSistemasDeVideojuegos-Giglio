using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitInfoFactory
{
    private static readonly Dictionary<string, UnitInfo> UnitInfos = new Dictionary<string, UnitInfo>();

    public static UnitInfo GetUnitInfo(string unitClass)
    {
        if (UnitInfos.TryGetValue(unitClass, out var unitInfo))
        {
            return unitInfo;
        }
        
        
        UnitInfo loadedUnitInfo = Resources.Load<UnitInfo>($"UnitInfos/{unitClass}");
        
        if (loadedUnitInfo == null)
        {
            Debug.LogError($"UnitInfo for class '{unitClass}' not found in Resources/UnitInfos!");
            return null;
        }

        UnitInfos[unitClass] = loadedUnitInfo;
        return loadedUnitInfo;
    }
}

