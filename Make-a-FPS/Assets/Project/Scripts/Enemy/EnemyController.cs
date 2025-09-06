using System;
using foRCreative.App.MakeAFps.Project.Scripts.SFX;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private RagdollSpawner ragdollSpawner;
        [SerializeField] private SePlayer sePlayer;
        
        [SerializeField] private GameObject enemyModel;
        [SerializeField] private GameObject enemyRootObj;

        public void Damage(float damage = 0)
        {
            Debug.Log("Damage received: " + damage);
            ragdollSpawner.SpawnRagdoll();
            
            //  ダメージSE再生
            sePlayer.PlayFirstAudioClip();
            
            //  敵オブジェクトを無効化
            enemyModel.SetActive(false);
            enemyRootObj.SetActive(false);
        }
    }
}
