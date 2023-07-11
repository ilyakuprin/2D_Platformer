using UnityEngine;

namespace JumpOrDie
{
    public class HealingReceiving : HealthChange
    {
        public void TakeHeal(int currentHealth, int maxHealth, GameObject healingPotion)
        {
            ChangeHealBar();

            healingPotion.GetComponent<Renderer>().enabled = false;
            healingPotion.GetComponent<Collider2D>().enabled = false;
        }
    }
}
