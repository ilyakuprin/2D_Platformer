using UnityEngine;

namespace Platformer2D
{
    public class VerticalAnimation
    {
        private readonly Animator _animator;
        private readonly HashAnimations _hashAnimations = new HashAnimations();
        private readonly float _velocityError;
        private bool _inJump = false;
        private bool _inFall = false;
        private float _rigidbodyVelocityY;

        public VerticalAnimation(Animator animator, float velocityError)
        {
            _animator = animator;
            _velocityError = velocityError;
        }

        public void Animation(float rigidbodyVelocityY)
        {
            _rigidbodyVelocityY = rigidbodyVelocityY;

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
    }
}
