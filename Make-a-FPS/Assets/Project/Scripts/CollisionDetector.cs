using UnityEngine;
using UnityEngine.Events;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Collider> onTriggerStayEvent;
        
        private void OnTriggerStay(Collider other)
        {
            onTriggerStayEvent.Invoke(other);
        }
    }
}
