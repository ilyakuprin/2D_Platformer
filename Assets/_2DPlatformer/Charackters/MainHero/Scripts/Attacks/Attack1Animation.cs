using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Attack1))]
    public class Attack1Animation : MonoBehaviour
    {
        private Animator _animator;
        private HorizontalMovement _horizontalMovement;
        private PlayerInput _playerInput;
        private AnimationMainHeroName _animationName;
        private readonly HashAnimations _hashAnimations = new HashAnimations();

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _horizontalMovement = GetComponent<HorizontalMovement>();
            _playerInput = GetComponent<PlayerInput>();
            _animationName = GetComponent<AnimationMainHeroName>();
        }

        public void StartAnimation()
        {
            StartCoroutine(EnabledMove());
            _animator.SetTrigger(_hashAnimations.Attack1);
        }

        private IEnumerator EnabledMove()
        {
            _playerInput.enabled = false;
            _horizontalMovement.enabled = false;

            yield return null;

            var nameAnim = _animationName.Attack1;
            while (_animator.GetCurrentAnimatorStateInfo(0).IsName(nameAnim))
            {
                yield return null;
            }

            _playerInput.enabled = true;
            _horizontalMovement.enabled = true;
        }

        private void OnEnable()
        {
            GetComponent<Attack1>().Attacked += StartAnimation;
        }

        private void OnDisable()
        {
            GetComponent<Attack1>().Attacked -= StartAnimation;
        }
    }
}
