using System.Collections;
using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.SFX;
using foRCreative.App.MakeAFps.Project.Scripts.VFX;
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
        NoAmmo = 2,
        
        /// <summary>
        /// リロード動作中
        /// </summary>
        Reloading = 3
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

        [Header("マガジンの最大弾数")]
        public int maxAmmo = 10;
        
        [Header("マガジン")]
        public int magazine;

        [Header("リロード時間")] 
        public int reloadTime = 10;

        [Header("FX系設定")]
        [SerializeField] private SePlayer sePlayer;
        [SerializeField] private EffectPlayer muzzleFlashEffect;
        
        //  現在の状態
        private HandGunState _state;
        
        //  発射クールダウンの待ち時間
        private WaitForSeconds _fireWaitSeconds;
        //  リロード完了待ち時間
        private WaitForSeconds _reloadWaitSeconds;

        private void Start()
        {
            _fireWaitSeconds = new WaitForSeconds(fireRate);
            _reloadWaitSeconds = new WaitForSeconds(reloadTime);
            
            WeaponAnimator = this.gameObject.GetComponent<Animator>();
            
            //  初期状態を設定
            _state = HandGunState.Idle;
            magazine = maxAmmo;
        }
        
        public override void WeaponUseUpdate(MyInputManager input)
        {
            switch (_state)
            {
                case HandGunState.Idle:
                    //  射撃可能
                    if (input.IsFireDown)
                    {
                        Fire();
                        //  マガジンが空の場合
                        if (magazine <= 0)
                        {
                            _state = HandGunState.NoAmmo;
                        }
                        else
                        {
                            _state = HandGunState.Firing;
                            StartCoroutine(FireCoolTimeCoroutine());
                        }
                    }
                    
                    //  リロード可能
                    if (input.IsReloadDown)
                    {
                        StartCoroutine(ReloadingCoroutine());
                    }
                    
                    break;
                case HandGunState.NoAmmo:
                    if (input.IsFireDown)
                    {
                        sePlayer.PlaySe("拳銃の弾切れ");
                    }
                    
                    //  リロード可能
                    if (input.IsReloadDown)
                    {
                        StartCoroutine(ReloadingCoroutine());
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
            
            //  銃のエフェクト
            sePlayer.PlaySe("拳銃を撃つ");
            muzzleFlashEffect.PlayEffect();
            
            //  攻撃アニメーションを再生
            WeaponAnimator.SetTrigger("Attack");
            
            //  マガジンの段数を減らす
            if (magazine > 0)
            {
                magazine--;
            }
        }
        
        IEnumerator FireCoolTimeCoroutine()
        {
            yield return _fireWaitSeconds;
            _state = HandGunState.Idle;
        }

        IEnumerator ReloadingCoroutine()
        {
            _state = HandGunState.Reloading;
            WeaponAnimator.SetTrigger("Reload");
            //  リロード音
            sePlayer.PlaySe("弾倉に弾を込める");
            
            yield return _reloadWaitSeconds;
            
            //  完了後にマガジンを満杯にて射撃準備完了
            sePlayer.PlaySe("拳銃をチャッと構える");
            magazine = maxAmmo;
            _state = HandGunState.Idle;
        }
    }
}
