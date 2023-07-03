using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(HealingReceiving), typeof(Health))]
    public class TakingHealthMainHero : MonoBehaviour
    {
        private Health _health;
        private HealingReceiving _healingReceiving;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _healingReceiving = GetComponent<HealingReceiving>();
        }

        public void TakeHeal(int heal, GameObject healingPotion)
        {
            int currentHeal = _health.CurrentValue;
            int maximumHeal = _health.MaximumValue;

            if (currentHeal < maximumHeal)
            {
                if (currentHeal + heal < maximumHeal)
                {
                    _health.CurrentValue += heal;
                }
                else
                {
                    _health.CurrentValue = maximumHeal;
                }

                _healingReceiving.TakeHeal(_health.CurrentValue, maximumHeal, healingPotion);
            }
        }
    }
}
