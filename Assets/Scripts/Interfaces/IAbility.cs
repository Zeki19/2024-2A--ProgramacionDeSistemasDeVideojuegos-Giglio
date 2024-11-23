using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    float GetCooldown();
    void Activate(Transform spawnPoint, Vector2 direction, int targetLayer);
}
