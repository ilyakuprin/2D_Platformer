using UnityEngine;

namespace Platformer2D
{
    public class EnemyMeleeAttackAudio : MonoBehaviour
    {
        private AudioSource _audioSource;
        private EnemyMeleeAttack _enemyMeleeAttack;
        private readonly float _minDistance = 0;
        private readonly float _maxDistance = 3;

        private void Awake()
        {
            _enemyMeleeAttack = transform.parent.GetComponent<EnemyMeleeAttack>();

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
            if (_audioSource != null)
            {
                _enemyMeleeAttack.Attacked += StartAudio;
            }
        }

        private void OnDisable()
        {
            if (_audioSource != null)
            {
                _enemyMeleeAttack.Attacked -= StartAudio;
            }
        }
    }
}
