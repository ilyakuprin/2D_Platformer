using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(PlayerInput), typeof(Animator), typeof(Rigidbody2D))]
    public class Attack1 : MeleeAttack
    {
        public event ToAttack Attacked;

        private Rigidbody2D _rigidbody;
        private Collider2D[] _enemies;
        private readonly float _errorVelocity = 0.01f;

        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Executive(InputData inputData)
        {
            if ((inputData.Fire1 && canAttack) && 
                (_rigidbody.velocity.y < _errorVelocity && _rigidbody.velocity.y > -_errorVelocity))
            {
                StartCoroutine(Recharge());

                Attacked?.Invoke();
            }
        }

        protected override void FixedUpdate()
        {
            _enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemy);
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
