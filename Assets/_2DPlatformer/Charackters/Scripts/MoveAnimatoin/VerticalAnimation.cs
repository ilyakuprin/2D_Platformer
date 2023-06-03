using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(VerticalMovement))]
    public class VerticalAnimation : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private readonly HashAnimations _hashAnimations = new HashAnimations();
        private readonly float _velocityError = 0.01f;
        private bool _inJump = false;
        private bool _inFall = false;
        private float _rigidbodyVelocityY;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void PlayAnimation()
        {
            _rigidbodyVelocityY = _rigidbody2D.velocity.y;

            if (!_inJump && _rigidbodyVelocityY > _velocityError)
            {
                _animator.SetBool(_hashAnimations.Jump, true);
                _animator.SetBool(_hashAnimations.Fall, false);
                _animator.SetBool(_hashAnimations.OnGround, false);

                _inFall = false;
                _inJump = true;
            }
            else if (!_inFall && _rigidbodyVelocityY < -_velocityError)
            {
                _animator.SetBool(_hashAnimations.Fall, true);
                _animator.SetBool(_hashAnimations.Jump, false);
                _animator.SetBool(_hashAnimations.OnGround, false);

                _inJump = false;
                _inFall = true;
            }
            else if ((_inJump || _inFall) && _rigidbodyVelocityY < _velocityError && _rigidbodyVelocityY > -_velocityError)
            {
                _animator.SetBool(_hashAnimations.OnGround, true);
                _animator.SetBool(_hashAnimations.Fall, false);
                _animator.SetBool(_hashAnimations.Jump, false);

                _inFall = false;
                _inJump = false;
            }
        }

        private void OnEnable()
        {
            GetComponent<VerticalMovement>().Moved += PlayAnimation;
        }

        private void OnDisable()
        {
            GetComponent<VerticalMovement>().Moved -= PlayAnimation;
        }
    }
}
