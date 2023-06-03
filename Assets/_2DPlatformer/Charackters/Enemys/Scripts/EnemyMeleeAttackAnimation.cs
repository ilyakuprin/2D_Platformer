using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    public class EnemyMeleeAttackAnimation : MonoBehaviour
    {
        [SerializeField] private Behaviour _playerTrackingScript;
        [SerializeField] private AnimationClip _attackAnimation;
        private Animator _animator;
        private EnemyMeleeAttack _enemyMeleeAttack;
        private readonly HashAnimations _hashAnimations = new HashAnimations();

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemyMeleeAttack = GetComponent<EnemyMeleeAttack>();
        }

        private void StartAnimation()
        {
            _animator.SetTrigger(_hashAnimations.Attack1);
            StartCoroutine(EnabledLookTowardsPlayer());
        }

        private IEnumerator EnabledLookTowardsPlayer()
        {
            _playerTrackingScript.enabled = false;

            if (TryGetComponent(out Rigidbody2D rigidbody))
            {
                rigidbody.velocity = Vector2.zero;
                _animator.SetBool(_hashAnimations.Run, false);
            }

            yield return new WaitForSeconds(_attackAnimation.length);

            if (enabled && _playerTrackingScript != null)
            {
                yield return _playerTrackingScript.enabled = true;
            }
        }

        private void OnEnable()
        {
            if (_enemyMeleeAttack != null)
            {
                _enemyMeleeAttack.Attacked += StartAnimation;
            }
        }

        private void OnDisable()
        {
            if (_enemyMeleeAttack != null)
            {
                _enemyMeleeAttack.Attacked -= StartAnimation;
            }
        }
    }
}
