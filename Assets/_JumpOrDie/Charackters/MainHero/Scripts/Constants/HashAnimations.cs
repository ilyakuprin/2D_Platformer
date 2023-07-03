using UnityEngine;

namespace JumpOrDie
{
    sealed public class HashAnimations
    {
        public int OnGround { get => Animator.StringToHash("OnGround"); }
        public int Run { get => Animator.StringToHash("Run"); }
        public int Jump { get => Animator.StringToHash("Jump"); }
        public int Fall { get => Animator.StringToHash("Fall"); }
        public int TakeHit { get => Animator.StringToHash("TakeHit"); }
        public int Death { get => Animator.StringToHash("Death"); }
        public int Attack1 { get => Animator.StringToHash("Attack1"); }
        public int Attack2 { get => Animator.StringToHash("Attack2"); }
        public int Attack3 { get => Animator.StringToHash("Attack3"); }
    }
}
