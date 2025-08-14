using System.Collections;
using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons.ScriptableObjectScript;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    public enum HandGunState
    {
        /// <summary>
        /// 発射準備完了
        /// </summary>
        Idle = 0,
        
        /// <summary>
        /// 発射動作中
        /// </summary>
        Firing = 1,
        
        /// <summary>
        /// 弾丸が装填されていない
        /// </summary>
        NoAmo = 2
    }
    public class HandGun : Weapon
    {
        [Header("弾丸")]
        [SerializeField] private GameObject bulletPrefab;
        
        [Header("弾初速")]
        [SerializeField] private float bulletSpeed = 100f;
        
        [Header("銃口")]
        [SerializeField] private Transform muzzle;

        [Header("連射可能速度")]
        [SerializeField] private float fireRate = 1f;
        
        //  現在の状態
        private HandGunState _state;
        
        private WaitForSeconds _fireWaitSeconds;
        

        private void Start()
        {
            _state = HandGunState.Idle;
            _fireWaitSeconds = new WaitForSeconds(fireRate);
            WeaponAnimator = this.gameObject.GetComponent<Animator>();
        }
        
        public override void WeaponUseUpdate(MyInputManager input)
        {
            switch (_state)
            {
                case HandGunState.Idle:
                    if (input.IsFireDown)
                    {
                        Fire();
                        _state = HandGunState.Firing;
                        WeaponAnimator.SetTrigger("Attack");
                        StartCoroutine(FireCoolTimeCoroutine());
                    }
                    break;
            }
        }
        
        /// <summary>
        /// 弾丸を発射
        /// </summary>
        private void Fire()
        {
            //  弾丸オブジェクト複製
            GameObject obj = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
            
            //  攻撃力情報を弾丸に付与
            if (obj.TryGetComponent(out Bullet bullet))
            {
                bullet.bulletData = (BulletData)weaponData;
            }
            
            //  弾丸に力を加える
            if (obj.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(muzzle.forward * bulletSpeed, ForceMode.Impulse);
            }
        }

        IEnumerator FireCoolTimeCoroutine()
        {
            yield return _fireWaitSeconds;
            _state = HandGunState.Idle;
        }
    }
}
