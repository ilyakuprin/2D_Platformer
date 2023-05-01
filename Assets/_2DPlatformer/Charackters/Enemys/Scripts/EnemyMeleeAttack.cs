using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Animator), typeof(VisibilityZone))]
    public class EnemyMeleeAttack : MeleeAttack
    {
        [SerializeField] private Behaviour _playerTrackingScript;
        [SerializeField] private AnimationClip _attackAnimation;
        private Animator _animator;
        private VisibilityZone _visibilityZone;
        private readonly HashAnimations _hashAnimations = new HashAnimations();

        protected override void Awake()
        {
            base.Awake();

            _animator = GetComponent<Animator>();
            _visibilityZone = GetComponent<VisibilityZone>();
        }

        private void Update()
        {
            if (_visibilityZone.SeePlayer)
            {
                if (_enemy != null && canAttack)
                {
                    if (_enemy.gameObject.GetComponent<PlayerInput>().enabled == true)
                    {
                        StartCoroutine(Recharge());
                        _animator.SetTrigger(_hashAnimations.Attack1);
                        StartCoroutine(EnabledLookTowardsPlayer());
                    }
                }
            }
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

            if (enabled)
            {
                yield return _playerTrackingScript.enabled = true;
            }
        }

        public void EnemyAttackMakeDamageEvent()
        {
            if (_enemy != null)
            {
                _enemy.GetComponent<TakingDamageMainHero>().TakeDamage(attackPower);
            }
        }
    }
}
