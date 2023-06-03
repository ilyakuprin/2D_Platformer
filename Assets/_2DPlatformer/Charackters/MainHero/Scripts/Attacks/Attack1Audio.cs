using UnityEngine;

namespace Platformer2D
{
    public class Attack1Audio : MonoBehaviour
    {
        private AudioSource _audioSource;
        private readonly float _minDistance = 0;
        private readonly float _maxDistance = 3;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.loop = false;
            _audioSource.playOnAwake = false;
            _audioSource.minDistance = _minDistance;
            _audioSource.maxDistance = _maxDistance;
        }

        private void StartAudio()
        {
            _audioSource.Play();
        }

        private void OnEnable()
        {
            transform.parent.GetComponent<Attack1>().Attacked += StartAudio;
        }

        private void OnDisable()
        {
            transform.parent.GetComponent<Attack1>().Attacked -= StartAudio;
        }
    }
}
