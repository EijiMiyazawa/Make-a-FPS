using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Interfaces;
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
        private Collider _attackCollider;

        private void Start()
        {
            _state = CrowbarState.Idle;
            WeaponAnimator = this.gameObject.GetComponent<Animator>();
            _attackCollider = GetComponent<Collider>();
            _attackCollider.enabled = false;
        }
        
        public override void Attack(bool isFire)
        {
            if (isFire)
            {
                if (_state == CrowbarState.Idle)
                {
                    _state = CrowbarState.Attacking;
                    //WeaponAnimator.SetTrigger("Attack");
                }
            }
            else
            {
                _state = CrowbarState.Idle;
            }
        }
        
        /// <summary>
        /// アニメーションイベント；攻撃有効
        /// </summary>
        public void CrowbarAttackEnable()
        {
            _attackCollider.enabled = true;
        }
        
        /// <summary>
        /// アニメーションイベント；攻撃無効
        /// </summary>
        public void CrowbarAttackDisable()
        {
            _attackCollider.enabled = false;
        }
        
        /// <summary>
        /// バールがヒット
        /// </summary>
        /// <param name="other">hit情報</param>
        public void CrowbarHit(Collider other)
        {
            if (other.TryGetComponent(out IAttackable attackable))
            {
                attackable.Damage(weaponData.WeaponDamage);
            }
        }
    }
}
