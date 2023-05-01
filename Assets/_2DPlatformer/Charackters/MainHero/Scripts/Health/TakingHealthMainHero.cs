using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(HealingReceiving))]
    public class TakingHealthMainHero : GetHealth
    {
        private HealingReceiving _healingReceiving;

        protected override void Awake()
        {
            base.Awake();
            _healingReceiving = GetComponent<HealingReceiving>();
        }

        public void TakeHeal(int heal, GameObject healingPotion)
        {
            int currentHeal = Health.CurrentValue;
            int maximumHeal = Health.MaximumValue;

            if (currentHeal < maximumHeal)
            {
                if (currentHeal + heal < maximumHeal)
                {
                    Health.CurrentValue += heal;
                }
                else
                {
                    Health.CurrentValue = maximumHeal;
                }

                _healingReceiving.TakeHeal(Health.CurrentValue, maximumHeal, healingPotion);
            }
        }
    }
}
