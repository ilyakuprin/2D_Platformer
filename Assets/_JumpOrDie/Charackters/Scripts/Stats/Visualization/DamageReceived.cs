using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(TakingDamage))]
    public class DamageReceived : HealthChange
    {
        public void TakeDamage()
        {
            if (!GetHealth.Dead())
            {
                ChangeHealBar();
                GetAnimator.SetTrigger(hashAnimations.TakeHit);
            }
        }

        private void OnEnable()
        {
            GetComponent<TakingDamage>().TookDamage += TakeDamage;
        }

        private void OnDisable()
        {
            GetComponent<TakingDamage>().TookDamage -= TakeDamage;
        }
    }
}
