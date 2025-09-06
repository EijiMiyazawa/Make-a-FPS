using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class RagdollSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ragdollPrefab;
        [SerializeField] private Transform original;
        
       public GameObject SpawnRagdoll()
        {
            GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation);
            if (ragdoll.TryGetComponent(out RagdollSetUpper ragdollSetUpper))
            {
                ragdollSetUpper.SetupRagdoll(original);
            }
            return ragdoll;
        }
    }
}
