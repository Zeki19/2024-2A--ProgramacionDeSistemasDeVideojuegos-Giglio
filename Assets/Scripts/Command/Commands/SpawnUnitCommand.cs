using System.Collections;
using System.Collections.Generic;
using Units;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnUnitCommand : ICommand
{
    private readonly IMediatorService _mediatorService;

    private readonly UnitClass _unitClass;
    private readonly bool _isEnemy;
    private readonly int _amount;
    
    private MonoBehaviour _executor;

    public SpawnUnitCommand(UnitClass unitClass, bool isEnemy, int amount)
    {
        _mediatorService = ServiceLocator.Instance.GetService<IMediatorService>();
        
        _unitClass = unitClass;
        _isEnemy = isEnemy;
        _amount = amount;
    }
    
    public void Execute()
    {
        _executor = CoroutineRunner.instance;
        _executor.StartCoroutine(SpawnWithDelay());
    }
    

    private IEnumerator SpawnWithDelay()
    {
        for (int i = 0; i < _amount; i++)
        {
            _mediatorService.SpawnUnit(_unitClass, _isEnemy);
            yield return new WaitForSeconds(1f);
        }
    }
    private UnitClass GetRandomUnitClass()
    {
        var unitClasses = (UnitClass[])System.Enum.GetValues(typeof(UnitClass));
        int randomIndex = Random.Range(0, unitClasses.Length - 1);
        return unitClasses[randomIndex];
    }
}
