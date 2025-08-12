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
        
        //  現在の状態
        private HandGunState _state;

        private void Start()
        {
            _state = HandGunState.Idle;
        }
        
        public override void Attack(bool isFire)
        {
            //  弾丸がない場合は発射しない
            if(_state == HandGunState.NoAmo) return;
            
            if (isFire)
            {
                if (_state == HandGunState.Idle)
                {
                    _state = HandGunState.Firing;
                    Fire();
                }
            }
            else
            {
                _state = HandGunState.Idle;
            }
        }
        
        /// <summary>
        /// 弾丸を発射
        /// </summary>
        private void Fire()
        {
            //  生成して力を加える
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
            
            if (bullet.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(muzzle.forward * bulletSpeed, ForceMode.Impulse);
            }
        }
    }
}
