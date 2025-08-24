using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.Enemy
{
    public class RagdollSetUpper : MonoBehaviour
    {
        [SerializeField] private Transform rootBone;

        public void SetupRagdoll(Transform originalRootBone)
        {
            CloneTransforms(originalRootBone,rootBone);
        }
        
        private void CloneTransforms(Transform root, Transform clone)
        {
            foreach (Transform child in root)
            {
                Transform cloneChild = clone.Find(child.name);
                if (cloneChild != null)
                {
                    cloneChild.position = child.position;
                    cloneChild.rotation = child.rotation;
                    CloneTransforms(child, cloneChild);
                }
            }
        }
    }
}
