using UnityEngine;

namespace Platformer2D
{
    public class HorizontalAnimation
    {
        private readonly GameObject _firePoint;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody;
        private readonly HashAnimations _hashAnimations = new HashAnimations();

        private readonly float _speedError;
        private readonly float _firePointX;
        private readonly float _firePointY;
        private readonly float _firePointZ;

        public HorizontalAnimation(SpriteRenderer spriteRenderer, Animator animator, Rigidbody2D rigidbody, float speedError, GameObject firePoint)
        {
            _spriteRenderer = spriteRenderer;
            _animator = animator;
            _rigidbody = rigidbody;
            _speedError = speedError;
            _firePoint = firePoint;

            Vector3 vectorPosition = firePoint.transform.localPosition;
            _firePointX = vectorPosition.x;
            _firePointY = vectorPosition.y;
            _firePointZ = vectorPosition.z;
        }

        public void PlayAnimation()
        {
            if (_rigidbody.velocity.x > _speedError)
            {
                _firePoint.transform.localPosition = new Vector3(_firePointX, _firePointY, _firePointZ);
                _spriteRenderer.flipX = false;
                _animator.SetBool(_hashAnimations.Run, true);
            }
            else if (_rigidbody.velocity.x < -_speedError)
            {
                _firePoint.transform.localPosition = new Vector3(-_firePointX, _firePointY, _firePointZ);
                _spriteRenderer.flipX = true;
                _animator.SetBool(_hashAnimations.Run, true);
            }
            else
            {
                _animator.SetBool(_hashAnimations.Run, false);
            }
        }
    }
}
