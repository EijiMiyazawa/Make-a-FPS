using foRCreative.App.MakeAFps.Project.Scripts.Interfaces;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class DamageReceiver : MonoBehaviour, IAttackable
    {
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private float damageMultiplier = 1f;
        
        public void Damage(float damage = 0)
        {
            enemyController.Damage(damage * damageMultiplier);
        }
    }
}
