using System;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons;
using TMPro;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.UI
{
    public class BulletCounter : MonoBehaviour
    {
        /// <summary>
        /// 使用中の武器
        /// </summary>
        public Weapon CurrentWeapon { get; set; }
        
        [SerializeField] private TextMeshProUGUI buttesText;

        private string _bulletsOfView = "";
        
        private void Update()
        {
            if (CurrentWeapon is HandGun gun)
            {
                int maxAmmo = gun.maxAmmo;
                int nowMagazine = gun.magazine;
                
                _bulletsOfView = $"{nowMagazine}/{maxAmmo}";
            }
            else
            {
                _bulletsOfView = "∞";
            }
            
            buttesText.text = _bulletsOfView;
        }
    }
}
