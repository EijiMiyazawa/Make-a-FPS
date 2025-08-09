using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    [RequireComponent(typeof(Animator))]
    public abstract class Weapon : MonoBehaviour
    {
        /// <summary>
        /// 読み取り専用(start時自動割り当て)
        /// </summary>
        [SerializeField] protected Animator weaponAnimator;

        /// <summary>
        /// 武器で攻撃
        /// </summary>
        public abstract void Attack(bool isFire = false);
    }
}
