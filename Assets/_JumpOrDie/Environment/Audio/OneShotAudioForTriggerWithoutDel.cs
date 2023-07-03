using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class OneShotAudioForTriggerWithoutDel : MonoBehaviour
    {
        private AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.loop = false;
            _audioSource.playOnAwake = false;
        }

        protected void PlayAudio()
        {
            _audioSource.Play();
        }
    }
}
