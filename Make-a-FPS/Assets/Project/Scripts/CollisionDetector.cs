using System;
using UnityEngine;
using UnityEngine.Events;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Collider> onTriggerStayEvent;
        [SerializeField] private UnityEvent<Collision> onCollisionEnterEvent;
        
        private void OnTriggerStay(Collider other)
        {
            onTriggerStayEvent.Invoke(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            onCollisionEnterEvent.Invoke(other);
        }
    }
}
