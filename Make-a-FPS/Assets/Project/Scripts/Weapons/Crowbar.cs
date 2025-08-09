using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    public enum CrowbarState
    {
        Idle = 0,
        Attacking = 1
    }
    
    public class Crowbar : Weapon
    {
        private CrowbarState _state;

        private void Start()
        {
            _state = CrowbarState.Idle;
        }
        
        public override void Attack(bool isFire = false)
        {
            if (isFire)
            {
                if (_state == CrowbarState.Idle)
                {
                    _state = CrowbarState.Attacking;
                    weaponAnimator.SetTrigger("Attack");
                }
            }
            else
            {
                _state = CrowbarState.Idle;
            }
        }
    }
}
