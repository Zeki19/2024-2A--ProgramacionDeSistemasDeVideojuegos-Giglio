using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class SpawnAllyRangedCommand : ISpawnCommand
{
    private UnitMediator _unitMediator;

    public SpawnAllyRangedCommand(UnitMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.RequestUnit(UnitClass.Ranged, false);
    }
}

public class SpawnAllyMeleeCommand : ISpawnCommand
{
    private UnitMediator _unitMediator;

    public SpawnAllyMeleeCommand(UnitMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.RequestUnit(UnitClass.Melee, false);
    }
}

public class SpawnEnemyMeleeCommand : ISpawnCommand
{
    private UnitMediator _unitMediator;

    public SpawnEnemyMeleeCommand(UnitMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.RequestUnit(UnitClass.Melee, true);
    }
}

public class SpawnEnemyRangedCommand : ISpawnCommand
{
    private UnitMediator _unitMediator;

    public SpawnEnemyRangedCommand(UnitMediator unitMediator)
    {
        _unitMediator = unitMediator;
    }

    public void Execute()
    {
        _unitMediator.RequestUnit(UnitClass.Ranged, true);
    }
}

public class SpawnWaveCommand : ISpawnCommand
{
    private UnitMediator _unitMediator;
    private MonoBehaviour _coroutineRunner;

    public SpawnWaveCommand(UnitMediator unitMediator, MonoBehaviour coroutineRunner)
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
            
            _unitMediator.RequestUnit(randomClass, true);
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}