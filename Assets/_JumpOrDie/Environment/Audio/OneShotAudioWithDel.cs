using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(AudioSource))]
    public class OneShotAudioWithDel : MonoBehaviour
    {
        private AudioClip _audioClip;
        private AudioSource _audioSource;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _audioSource = GetComponent<AudioSource>(); 
            _audioSource.playOnAwake = false;

            _audioClip = _audioSource.clip;
        }

        private void Start()
        {
            StartCoroutine(PlayAndDestroy());
        }

        private IEnumerator PlayAndDestroy()
        {
            while (_renderer.enabled)
            {
                yield return null;
            }

            _audioSource.PlayOneShot(_audioClip);
            Destroy(gameObject, _audioClip.length);
            yield return null;
        }
    }
}
