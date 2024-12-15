using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour
{
    private readonly Dictionary<string, IAbility> _abilities = new Dictionary<string, IAbility>();

    public AbilityFactory()
    {
        _abilities.Add("Fireball", new FireballAbility());
        _abilities.Add("Portal", new PortalAbility());
    }

    public IAbility GetAbility(string abilityName)
    {
        if (_abilities.TryGetValue(abilityName, out IAbility ability))
        {
            return ability;
        }

        Debug.LogWarning($"Ability '{abilityName}' not found.");
        return null;
    }
}
