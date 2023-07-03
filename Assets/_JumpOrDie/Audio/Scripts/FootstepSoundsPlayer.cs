using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(AudioSource))]
    public class FootstepSoundsPlayer : FootstepSounds
    {
        [SerializeField] private AudioClip _grass;
        [SerializeField] private AudioClip _stones;
        [SerializeField] private AudioClip _wood;
        private readonly float _minDistance = 0;
        private readonly float _maxDistance = 3;
        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();
            _audioSource.loop = true;
            _audioSource.playOnAwake = false;
            _audioSource.minDistance = _minDistance;
            _audioSource.maxDistance = _maxDistance;
        }

        private void Start()
        {
            StartCoroutine(PlayStopAudio());
        }

        private IEnumerator PlayStopAudio()
        {
            while (true)
            {
                while (!WalksEarth)
                {
                    yield return null;
                }

                AssignAudioClip();
                _audioSource.Play();

                while (WalksEarth)
                {
                    yield return null;
                }

                _audioSource.Stop();
            }
        }

        private void AssignAudioClip()
        {
            var groundTag = GroundedTag;

            if (groundTag == TagName.Grass)
            {
                _audioSource.clip = _grass;
            }
            else if (groundTag == TagName.Wood)
            {
                _audioSource.clip = _wood;
            }
            else if (groundTag == TagName.Stones)
            {
                _audioSource.clip = _stones;
            }
            else
            {
                _audioSource.clip = null;
            }
        }
    }
}
