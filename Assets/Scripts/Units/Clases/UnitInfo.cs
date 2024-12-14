using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;

[CreateAssetMenu(fileName = "NewUnitData", menuName = "Units/UnitInfo")]
    public class UnitInfo : ScriptableObject
    {
        public UnitClass unitClass;
        public int maxHealth;
        public float movementSpeed;
        public int damage;
        public float attackCooldown;
        public float range;

        public Sprite classSprite;
    }
