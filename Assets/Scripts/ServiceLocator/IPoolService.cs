using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolService
{
    public void ReturnToPool(GameObject obj);
    public GameObject GetFromPoolByName(string prefabName);
}
