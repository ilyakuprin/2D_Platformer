using UnityEngine;

namespace Platformer2D
{
    public class TouchHeart : InteractionWithItems
    {
        protected override void MakeAction(GameObject player)
        {
            player.GetComponent<TakingHeartMainHero>().TakeHeart(gameObject);
        }
    }
}
