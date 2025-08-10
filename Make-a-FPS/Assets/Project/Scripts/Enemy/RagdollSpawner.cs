using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class RagdollSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ragdollPrefab;
        [SerializeField] private Transform original;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void SpawnRagdoll()
        {
            Transform ragdoll = Instantiate(ragdollPrefab, original.position,original.rotation).transform;
            CloneTransforms(original, ragdoll);
        }

        private void CloneTransforms(Transform root, Transform clone)
        {
            foreach (Transform child in root)
            {
                Transform cloneChild = child.Find(child.name);
                if (cloneChild != null)
                {
                    clone.position = cloneChild.position;
                    clone.rotation = cloneChild.rotation;
                    CloneTransforms(child, cloneChild);
                }
            }
        }
    }
}
