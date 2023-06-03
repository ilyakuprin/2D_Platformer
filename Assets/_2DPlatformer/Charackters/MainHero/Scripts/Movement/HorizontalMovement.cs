using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput), typeof(Animator))]
    public class HorizontalMovement : MonoBehaviour, IMainHeroAction
    {
        public delegate void ToMove();
        public event ToMove Moved;

        [SerializeField, Range(0.5f, 2f)] private float _speed;
        private Rigidbody2D _rigidbody;
        private float _horizontalForce = 0;
        private readonly float _speedError = 0.01f;
        private float _inputHorizontalDirection = 0;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Executive(InputData inputData)
        {
            _inputHorizontalDirection = inputData.HorizontalDirection;
            if (_inputHorizontalDirection > _speedError || _inputHorizontalDirection < -_speedError)
            {
                _horizontalForce = _inputHorizontalDirection * _speed;
            }

            Moved?.Invoke();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_horizontalForce, _rigidbody.velocity.y);
        }

        private void OnEnable()
        {
            _horizontalForce = 0;
            GetComponent<PlayerInput>().Inputted += Executive;
        }

        private void OnDisable()
        {
            GetComponent<PlayerInput>().Inputted -= Executive;
        }
    }
}
