using UnityEngine;

namespace Units
{
    public class UnitButton : MonoBehaviour
    {
        public bool isEnemy;
        public UnitClass unitClass;
        public UnitMediator mediator;
        
        public void OnButtonClick()
        {
            if (mediator != null)
            {
                mediator.RequestUnit(unitClass, isEnemy);
            }
        }
    }
}
