using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons.ScriptableObjectScript
{
    [CreateAssetMenu(fileName = "NewBulletData", menuName = "Scriptable Objects/BulletData")]
    public class BulletData : WeaponData
    {
        [Header("射程距離")]
        public float BulletRange = 10f;
        [Header("距離減衰(射程距離まで)")]
        public AnimationCurve BulletPowerDecay;
        
        /// <summary>
        /// 現在の距離を踏まえたダメージを返す
        /// </summary>
        /// <param name="bulletDistance">現時点の距離</param>
        /// <returns></returns>
        public float DamageAtDistance(float bulletDistance)
        {
            return WeaponDamage * BulletPowerDecay.Evaluate(bulletDistance/BulletRange);
        }
    }
}
