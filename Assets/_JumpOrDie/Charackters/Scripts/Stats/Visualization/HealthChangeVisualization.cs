using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(Animator), typeof(UIFields), typeof(Health))]
    public abstract class HealthChangeVisualization : MonoBehaviour
    {
        private Animator _animator;
        private UIFields _uiFields;
        private Health _health;
        protected readonly HashAnimations hashAnimations = new HashAnimations();

        protected Animator GetAnimator { get => _animator; }
        protected UIFields GetUIFields { get => _uiFields; }
        protected Health GetHealth { get => _health; }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            _uiFields = GetComponent<UIFields>();
            _health = GetComponent<Health>();
        }
    }
}
