using System;
using foRCreative.App.MakeAFps.Project.Scripts.Interfaces;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IAttackable
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Damage(float damage = 0)
        {
            Debug.Log("Damage received: " + damage);
        }

    }
}
