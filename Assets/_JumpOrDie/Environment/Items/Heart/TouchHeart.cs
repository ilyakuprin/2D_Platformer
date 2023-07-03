using UnityEngine;

namespace JumpOrDie
{
    public class TouchHeart : InteractionWithItems
    {
        protected override void MakeAction(GameObject player)
        {
            player.GetComponent<TakingHeartMainHero>().TakeHeart(gameObject);
        }
    }
}
