using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts.SFX
{
    public static class AudioSourceExtensions
    {
        public static void Play(this AudioSource audioSource, AudioClip audioClip = null, float volume = 1.0f)
        {
            if (audioClip)
            {
                audioSource.clip = audioClip;
                audioSource.volume = Mathf.Clamp01(volume);
                audioSource.Play();
            }
        }
    }
}
