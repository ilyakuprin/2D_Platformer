using UnityEngine;

namespace Platformer2D
{
    public class Attack1Animation
    {
        private readonly Animator _animator;
        private readonly HashAnimations _hashAnimations = new HashAnimations();

        public Attack1Animation(Animator animator)
        {
            _animator = animator;
        }

        public void Animation()
        {
            _animator.SetTrigger(_hashAnimations.Attack1);
        }
    }
}
