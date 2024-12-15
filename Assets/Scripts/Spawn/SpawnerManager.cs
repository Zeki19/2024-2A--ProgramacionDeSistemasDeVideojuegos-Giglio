using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField] private Transform ally;
        [SerializeField] private Transform enemy;
        
        public void SpawnUnit(GameObject unit, bool isEnemy, Vector3? spawnPosition = null)
        {
            if (spawnPosition != null)
            {
                unit.transform.position = spawnPosition.Value;
                unit.SetActive(true);
            }
            else
            {
                unit.transform.position = isEnemy ? enemy.position : ally.position;
                unit.SetActive(true);
            }
        }
    }

