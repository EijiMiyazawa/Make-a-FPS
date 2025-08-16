using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class RagdollSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ragdollPrefab;
        [SerializeField] private Transform original;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public GameObject SpawnRagdoll()
        {
            GameObject ragdoll = Instantiate(ragdollPrefab, original.position, original.rotation);
            CloneTransforms(original, ragdoll.transform);
            return ragdoll;
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
