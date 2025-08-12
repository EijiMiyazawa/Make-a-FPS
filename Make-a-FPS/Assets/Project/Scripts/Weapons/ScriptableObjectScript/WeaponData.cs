using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Weapons.ScriptableObjectScript
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
    public class WeaponData : UnityEngine.ScriptableObject
    {
        [Header("与えるダメージ")]
        public float WeaponDamage;
    }
}
