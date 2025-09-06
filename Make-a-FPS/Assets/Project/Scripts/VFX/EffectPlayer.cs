using System;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.VFX
{
    [RequireComponent(typeof(ParticleSystem))]
    public class EffectPlayer : MonoBehaviour
    {
        private ParticleSystem _particle;

        private void Start()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        public void PlayEffect()
        {
            _particle.Play();
        }
        
        public void PlayEffect(Vector3 startPosition,Quaternion startRotation)
        {
            _particle.gameObject.transform.position = startPosition;
            _particle.gameObject.transform.rotation = startRotation;
            PlayEffect();
        }

        public void PauseEffect()
        {
            _particle.Pause();
        }

        public void StopEffect()
        {
            _particle.Stop();
        }
    }
}
