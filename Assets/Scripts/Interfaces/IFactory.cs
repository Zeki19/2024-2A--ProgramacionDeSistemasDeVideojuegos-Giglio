using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Units;
using UnityEngine;


public interface IFactory
{
    GameObject Create([CanBeNull] string name);
}
