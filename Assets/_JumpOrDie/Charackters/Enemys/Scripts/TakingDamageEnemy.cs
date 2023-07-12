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
            _health = GetComponent<Health>();
            _damageReceived = GetComponent<DamageReceived>();
            _deathEnemy = GetComponent<DeathEnemy>();
        }

        public void TakeDamage(int damage)
        {
            _health.Reduce(damage);
            
            if (!_health.Dead())
            {
                _damageReceived.TakeDamage();
            }
            else
            {
                _deathEnemy.Die();
            }
        }
    }
}
