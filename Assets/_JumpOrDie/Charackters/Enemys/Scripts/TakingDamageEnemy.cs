using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(DamageReceived), typeof(DeathEnemy), typeof(Health))]
    public class TakingDamageEnemy : MonoBehaviour
    {
        private Health _health;
        private DamageReceived _damageReceived;
        private DeathEnemy _deathEnemy;

        private void Awake()
        {
            _damageReceived = GetComponent<DamageReceived>();
            _deathEnemy = GetComponent<DeathEnemy>();
            _health = GetComponent<Health>();
        }

        public void TakeDamage(int damage)
        {
            _health.Reduce(damage);

            if(!_health.Dead())
            {
                _damageReceived.TakeDamage(_health.CurrentValue, _health.MaximumValue);
            }
            else
            {
                _deathEnemy.Die();
            }
        }
    }
}
