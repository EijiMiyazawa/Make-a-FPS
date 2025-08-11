using foRCreative.App.MakeAFps.Project.Scripts.Weapons;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons
{
    public class Gun : Weapon
    {
        [SerializeField] private GameObject bulletPrefab;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void Attack(bool isFire)
        {
            //throw new System.NotImplementedException();
        }

    }
}
