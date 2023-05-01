using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(DamageReceived), typeof(DeathMainHero))]
    public class TakingDamageMainHero : GetHealth
    {
        private DamageReceived _damageReceived;
        private DeathMainHero _deathMainHero;

        protected override void Awake()
        {
            base.Awake();
            _damageReceived = GetComponent<DamageReceived>();
            _deathMainHero = GetComponent<DeathMainHero>();
        }

        public void TakeDamage(int damage)
        {
            Health.CurrentValue -= damage;

            if (Health.CurrentValue <= 0)
            {
                _deathMainHero.Die();
            }
            else
            {
                _damageReceived.TakeDamage(Health.CurrentValue, Health.MaximumValue);
            }
        }
    }
}
