using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    public class Crowbar : Weapon
    {
        public override void Attack(bool isFire = false)
        {
            WeaponAnimator.SetBool("IsAttacking", isFire);
        }
    }
}
