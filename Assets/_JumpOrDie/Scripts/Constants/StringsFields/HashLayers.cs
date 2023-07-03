using UnityEngine;

namespace JumpOrDie
{
    sealed public class HashLayers
    {
        public int Water { get => LayerMask.NameToLayer("Water"); }
        public int Enemy { get => LayerMask.NameToLayer("Enemy"); }
        public int Player { get => LayerMask.NameToLayer("Player"); }
        public int Nothing { get => LayerMask.NameToLayer("Nothing"); }
        public int GroundAfterJumpingDown { get => LayerMask.NameToLayer("GroundAfterJumpingDown"); }
        public int NoJump { get => LayerMask.NameToLayer("NoJump"); }
    }
}
