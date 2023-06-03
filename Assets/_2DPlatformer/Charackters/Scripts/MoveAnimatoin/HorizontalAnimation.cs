using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(HorizontalMovement))]
    public class HorizontalAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _firePoint;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private readonly HashAnimations _hashAnimations = new HashAnimations();

        private readonly float _speedError = 0.01f;
        private float _firePointX;
        private float _firePointY;
        private float _firePointZ;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();

            Vector3 vectorPosition = _firePoint.transform.localPosition;
            _firePointX = vectorPosition.x;
            _firePointY = vectorPosition.y;
            _firePointZ = vectorPosition.z;
        }

        private void PlayAnimation()
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

        private void OnEnable()
        {
            GetComponent<HorizontalMovement>().Moved += PlayAnimation;
        }

        private void OnDisable()
        {
            GetComponent<HorizontalMovement>().Moved -= PlayAnimation;
        }
    }
}
