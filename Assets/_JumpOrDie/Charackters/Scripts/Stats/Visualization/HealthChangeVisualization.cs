using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(Animator), typeof(UIFields))]
    public abstract class HealthChangeVisualization : MonoBehaviour
    {
        private Animator _animator;
        private UIFields _uiFields;
        protected readonly HashAnimations hashAnimations = new HashAnimations();

        protected Animator GetAnimator { get => _animator; }
        protected UIFields GetUIFields { get => _uiFields; }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            _uiFields = GetComponent<UIFields>();
        }
    }
}
