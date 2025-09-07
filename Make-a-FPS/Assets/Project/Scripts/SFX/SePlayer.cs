using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace foRCreative.App.MakeAFps.Project.Scripts.SFX
{
    [RequireComponent(typeof(AudioSource))]
    public class SePlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        public List<AudioClip> audioClips = new List<AudioClip>();

        /// <summary>
        /// リストにある最初のClipを再生
        /// </summary>
        public void PlayFirstAudioClip()
        {
            if (audioClips.Count > 0)
            {
                audioSource.pitch = 1f;
                audioSource.Play(audioClips[0]);
            }
        }
        
        /// <summary>
        /// リストにある最初のClipを再生
        /// </summary>
        /// <param name="randomPitch">ランダムなピッチ</param>
        public void PlayFirstAudioClip(float randomPitch)
        {
            if (audioClips.Count > 0)
            {
                audioSource.pitch = Random.Range(1f - randomPitch, 1f + randomPitch);
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

            if (audioClip)
            {
                audioSource.pitch = 1f;
                audioSource.Play(audioClip);
            }
        }

        /// <summary>
        /// Clip名を指定して再生
        /// </summary>
        /// <param name="audioClipName">Clip名</param>
        /// <param name="randomPitch">ランダムなピッチ</param>
        public void PlaySe(string audioClipName, float randomPitch)
        {
            AudioClip audioClip = audioClips.Find(x => x.name == audioClipName);

            if (audioClip)
            {
                audioSource.pitch = Random.Range(1f - randomPitch, 1f + randomPitch);
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
