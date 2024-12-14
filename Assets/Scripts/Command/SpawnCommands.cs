using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class SpawnAllyRangedCommand : ISpawnCommand
{
    private NpcMediator _unitMediator;

    public SpawnAllyRangedCommand(NpcMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.SpawnUnit(UnitClass.Ranged, false);
    }
}

public class SpawnAllyMeleeCommand : ISpawnCommand
{
    private NpcMediator _unitMediator;

    public SpawnAllyMeleeCommand(NpcMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.SpawnUnit(UnitClass.Melee, false);
    }
}

public class SpawnEnemyMeleeCommand : ISpawnCommand
{
    private NpcMediator _unitMediator;

    public SpawnEnemyMeleeCommand(NpcMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.SpawnUnit(UnitClass.Melee, true);
    }
}

public class SpawnEnemyRangedCommand : ISpawnCommand
{
    private NpcMediator _unitMediator;

    public SpawnEnemyRangedCommand(NpcMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.SpawnUnit(UnitClass.Ranged, true);
    }
}

public class SpawnWaveCommand : ISpawnCommand
{
    private NpcMediator _unitMediator;
    private MonoBehaviour _coroutineRunner;

    public SpawnWaveCommand(NpcMediator unitMediator, MonoBehaviour coroutineRunner)
    {
        _unitMediator = unitMediator;
        _coroutineRunner = coroutineRunner;
    }

    public void Execute()
    {
        _coroutineRunner.StartCoroutine(SpawnWaveCoroutine());
    }

    private IEnumerator SpawnWaveCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            UnitClass randomClass = Random.value > 0.5f ? UnitClass.Melee : UnitClass.Ranged;
            
            _unitMediator.SpawnUnit(randomClass, true);
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}