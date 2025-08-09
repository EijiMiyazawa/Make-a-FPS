using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    [RequireComponent(typeof(Animator))]
    public abstract class Weapon : MonoBehaviour
    {
        /// <summary>
        /// 読み取り専用(start時自動割り当て)
        /// </summary>
        public Animator WeaponAnimator { get; private set; }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            WeaponAnimator  = GetComponent<Animator>();
            if (WeaponAnimator == null)
            {
                Debug.LogError("This Weapon not attached Animator");
            }
        }

        /// <summary>
        /// 武器で攻撃
        /// </summary>
        public abstract void Attack(bool isFire = false);
    }
}
