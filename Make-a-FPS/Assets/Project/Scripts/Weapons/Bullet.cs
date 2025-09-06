using foRCreative.App.MakeAFps.Project.Scripts.Interfaces;
using foRCreative.App.MakeAFps.Project.Scripts.VFX;
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
        
        [SerializeField] private Rigidbody rigidBody;

        /// <summary>
        /// ヒット後、消滅までの時間
        /// </summary>
        [SerializeField] private float lifeTimeAfterHits = 10f;
        
        /// <summary>
        /// ヒットエフェクト再生用
        /// </summary>
        [SerializeField] private EffectPlayer hitEffect;
        
        /// <summary>
        /// 弾丸がコライダーにヒット
        /// </summary>
        /// <param name="other">コライダー情報</param>
        public void BulletHit(Collision other)
        {
            rigidBody.isKinematic = true;
            
            hitEffect.PlayEffect(other.contacts[0].point, Quaternion.LookRotation(other.contacts[0].normal));
            
            if (other.collider.TryGetComponent(out IAttackable attackable))
            {
                attackable.Damage(bulletData.WeaponDamage);
            }
            
            //  ヒットした弾丸は無効
            Destroy(this.gameObject, lifeTimeAfterHits);
        }
    }
}
