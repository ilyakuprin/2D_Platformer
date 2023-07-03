using UnityEngine;

namespace JumpOrDie
{
    sealed public class AnimationMainHeroName : MonoBehaviour
    {
        [HideInInspector] public string Attack1;
        [SerializeField] private AnimationClip _attack1;

        private void Awake()
        {
            Attack1 = _attack1.name;
        }
    }
}
