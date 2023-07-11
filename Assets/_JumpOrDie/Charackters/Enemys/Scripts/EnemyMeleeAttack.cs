using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(Animator), typeof(VisibilityZone))]
    public class EnemyMeleeAttack : MeleeAttack
    {
        public event ToAttack Attacked;

        private VisibilityZone _visibilityZone;

        protected override void Awake()
        {
            base.Awake();

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

                        Attacked?.Invoke();
                    }
                }
            }
        }

        public void EnemyAttackMakeDamageEvent()
        {
            if (_enemy != null)
            {
                _enemy.GetComponent<TakingDamage>().TakeDamage(attackPower);
            }
        }
    }
}
