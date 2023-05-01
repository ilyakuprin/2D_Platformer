using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(PlayerInput), typeof(Animator), typeof(Rigidbody2D))]
    public class Attack1 : MeleeAttack
    {
        private Attack1Animation _attack1Animation;
        private Rigidbody2D _rigidbody;
        private Collider2D[] _enemies;
        private Animator _animator;
        private readonly float _errorVelocity = 0.01f;

        private HorizontalMovement _horizontalMovement;
        private PlayerInput _playerInput;

        private AnimationMainHeroName _animationName;

        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
            _horizontalMovement = GetComponent<HorizontalMovement>();
            _animator = GetComponent<Animator>();
            _animationName = GetComponent<AnimationMainHeroName>();

            _attack1Animation = new Attack1Animation(_animator);

            _playerInput = GetComponent<PlayerInput>();
        }

        public void Executive(InputData inputData)
        {
            if ((inputData.Fire1 && canAttack) && 
                (_rigidbody.velocity.y < _errorVelocity && _rigidbody.velocity.y > -_errorVelocity))
            {
                _attack1Animation.Animation();
                StartCoroutine(Recharge());
                StartCoroutine(EnabledMove());
            }
        }

        protected override void FixedUpdate()
        {
            _enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemy);
        }

        private IEnumerator EnabledMove()
        {
            _playerInput.enabled = false;
            _horizontalMovement.enabled = false;

            yield return null;

            var nameAnim = _animationName.Attack1;
            while (_animator.GetCurrentAnimatorStateInfo(0).IsName(nameAnim))
            {
                yield return null;
            }

            _playerInput.enabled = true;
            _horizontalMovement.enabled = true;
        }

        public void Attack1MakeDamageEvent()
        {
            if (_enemies != null)
            {
                for (int i = 0; i < _enemies.Length; i++)
                {
                    _enemies[i].GetComponent<TakingDamageEnemy>().TakeDamage(attackPower);
                }
            }
        }

        private void OnEnable()
        {
            GetComponent<PlayerInput>().Inputted += Executive;
        }

        private void OnDisable()
        {
            GetComponent<PlayerInput>().Inputted -= Executive;
        }
    }
}
