using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(DamageReceived), typeof(DeathMainHero), typeof(Health))]
    public class TakingDamageMainHero : MonoBehaviour
    {
        private Health _health;
        private DamageReceived _damageReceived;
        private DeathMainHero _deathMainHero;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _damageReceived = GetComponent<DamageReceived>();
            _deathMainHero = GetComponent<DeathMainHero>();
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
                _deathMainHero.Die();
            }
        }
    }
}
