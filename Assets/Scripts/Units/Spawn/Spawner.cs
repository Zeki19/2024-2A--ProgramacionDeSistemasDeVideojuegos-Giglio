using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units
{
    public class Spawner : MonoBehaviour //Lazy singleton
    {
        private static Spawner _instance;
        public static Spawner Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindObjectOfType<Spawner>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("Spawner");
                    _instance = singletonObject.AddComponent<Spawner>();
                }
                return _instance;
            }
        }
        
        [SerializeField] Transform Ally;
        [SerializeField] Transform Enemy;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }


        public void SpawnUnit(GameObject unit, bool isEnemy)
        {
            unit.transform.position = isEnemy ? Enemy.position : Ally.position;
        }
    }
}
