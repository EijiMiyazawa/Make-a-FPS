using foRCreative.App.MakeAFps.Project.Scripts.Interfaces;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons.ScriptableObjectScript;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// 弾丸のダメージ情報
        /// </summary>
        public BulletData bulletData;
        
        /// <summary>
        /// 弾丸がコライダーにヒット
        /// </summary>
        /// <param name="other">コライダー情報</param>
        public void BulletHit(Collision other)
        {
            if (other.collider.TryGetComponent(out IAttackable attackable))
            {
                attackable.Damage(bulletData.WeaponDamage);
            }
            //  ヒットした弾丸は無効
            Destroy(this.gameObject);
        }
    }
}
