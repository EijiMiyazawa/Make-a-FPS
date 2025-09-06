using System;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private RagdollSpawner ragdollSpawner;

        public void Damage(float damage = 0)
        {
            Debug.Log("Damage received: " + damage);
            ragdollSpawner.SpawnRagdoll();
            this.gameObject.SetActive(false);
        }
    }
}
