using System;
using System.Collections.Generic;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.SFX
{
    [RequireComponent(typeof(AudioSource))]
    public class SePlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        public List<AudioClip> audioClips = new List<AudioClip>();

        public void PlayFirstAudioClip()
        {
            if (audioClips.Count > 0)
            {
                audioSource.Play(audioClips[0]);
            }
        }
        
        /// <summary>
        /// Clip名を指定して再生
        /// </summary>
        /// <param name="audioClipName">Clip名</param>
        public void PlaySe(string audioClipName)
        {
            AudioClip audioClip = audioClips.Find(x => x.name == audioClipName);

            if (audioClip != null)
            {
                audioSource.pitch = 1f;
                audioSource.Play(audioClip);
            }
        }
        
        public void Reset()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0.7f;
        }
    }
}
