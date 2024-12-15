using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbillityService
{
    public void UseAbility(Transform spawnPoint, Vector2 direction, int targetLayer);
}
