using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(DamageReceived), typeof(DeathEnemy))]
    public class TakingDamageEnemy : GetHealth
    {
        private DamageReceived _damageReceived;
        private DeathEnemy _deathEnemy;

        protected override void Awake()
        {
            base.Awake();
            _damageReceived = GetComponent<DamageReceived>();
            _deathEnemy = GetComponent<DeathEnemy>();
        }

        public void TakeDamage(int damage)
        {
            Health.CurrentValue -= damage;

            if (Health.CurrentValue <= 0)
            {
                _deathEnemy.Die();
            }
            else
            {
                _damageReceived.TakeDamage(Health.CurrentValue, Health.MaximumValue);
            }
        }
    }
}
