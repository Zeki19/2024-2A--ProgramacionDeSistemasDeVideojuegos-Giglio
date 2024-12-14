using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbstractFactory
{
    GameObject CreateArrow();
    GameObject CreateUnit();

}
