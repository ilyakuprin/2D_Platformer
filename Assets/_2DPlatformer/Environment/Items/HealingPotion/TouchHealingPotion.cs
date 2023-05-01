using UnityEngine;

namespace Platformer2D
{
    public class TouchHealingPotion : InteractionWithItems
    {
        private readonly int _healValue = 2;

        protected override void MakeAction(GameObject player)
        {
            player.GetComponent<TakingHealthMainHero>().TakeHeal(_healValue, gameObject);
        }
    }
}
