using System;
using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons.ScriptableObjectScript;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    [RequireComponent(typeof(Animator))]
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Weapon Data")]
        [SerializeField] protected WeaponData weaponData;
        
        /// <summary>
        /// 読み取り専用(start時自動割り当て)
        /// </summary>
        protected Animator WeaponAnimator;

        /// <summary>
        /// 武器で攻撃
        /// </summary>
        /// <param name="input">入力情報</param>
        public abstract void WeaponUseUpdate(MyInputManager input);

        private void Start()
        {
            WeaponAnimator = this.gameObject.GetComponent<Animator>();
        }
    }
}
