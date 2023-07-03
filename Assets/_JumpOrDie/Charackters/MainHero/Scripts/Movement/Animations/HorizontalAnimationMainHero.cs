using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(HorizontalMovement))]
    public class HorizontalAnimationMainHero : HorizontalAnimation
    {
        private void OnEnable()
        {
            GetComponent<HorizontalMovement>().Moved += PlayAnimation;
        }

        private void OnDisable()
        {
            GetComponent<HorizontalMovement>().Moved -= PlayAnimation;
        }
    }
}
