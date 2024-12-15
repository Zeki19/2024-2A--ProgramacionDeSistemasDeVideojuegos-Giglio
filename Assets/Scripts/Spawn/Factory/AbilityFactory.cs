using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour, IFactory
{
    [Header("Ability Prefabs")]
    [SerializeField] private List<AbilityEntry> abilities;
    
    private Dictionary<string, GameObject> _abilityDictionary;
    
    private void Awake()
    {
        InitializeAbilityDictionary();
    }
    private void InitializeAbilityDictionary()
    {
        _abilityDictionary = new Dictionary<string, GameObject>();
        
        foreach (var entry in abilities)
        {
            if (!_abilityDictionary.ContainsKey(entry.abilityName))
            {
                _abilityDictionary.Add(entry.abilityName, entry.prefab);
            }
            else
            {
                Debug.LogWarning($"Duplicate ability name found: {entry.abilityName}");
            }
        }
    }

    public GameObject Create(string abilityName)
    {
        if (_abilityDictionary.TryGetValue(abilityName, out GameObject prefab))
        {
            GameObject ability = Instantiate(prefab);
            ability.SetActive(false);
            return ability;
        }
        
        return null;
    }
}

[System.Serializable]
public class AbilityEntry
{
    public string abilityName;
    public GameObject prefab;
}

