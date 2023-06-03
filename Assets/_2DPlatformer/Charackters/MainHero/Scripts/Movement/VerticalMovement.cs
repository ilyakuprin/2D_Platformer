using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    [RequireComponent(typeof(PlayerInput), typeof(VerticalAnimation))]
    public class VerticalMovement : MonoBehaviour, IMainHeroAction
    {
        public delegate void ToMove();
        public event ToMove Moved;

        [SerializeField, Range(1, 10)] private float _jumpForce;
        [SerializeField, Range(1, 3)] private int _numberJumps;
        [SerializeField, Range(0.01f, 0.2f)] private float _jumpCircleRadius;
        [SerializeField] private Transform _groundCheckerTransform;
        [SerializeField] private LayerMask _groundMask;

        private LayersWhereCantJump _layersWhereCantJump;
        private Rigidbody2D _rigidbody;
        private bool _isGrounded = false;
        private bool _gottaJump = false;
        private int _currentNumberJumps;
        private int _layerContact;
        private readonly float _velocityError = 0.01f;

        private void Awake()
        {
            _layersWhereCantJump = new LayersWhereCantJump(new HashLayers());
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Executive(InputData inputData)
        {
            float rbVelocityY = _rigidbody.velocity.y;
            if (_isGrounded && !_gottaJump && (rbVelocityY < _velocityError && rbVelocityY > -_velocityError))
            {
                _currentNumberJumps = _numberJumps;
            }

            if (inputData.Jump && !_gottaJump && _currentNumberJumps > 0 && 
                _layersWhereCantJump.LayersInaccessibleJump(_layerContact))
            {
                _gottaJump = true;
                _currentNumberJumps--;
            }

            Moved?.Invoke();
        }
        private void FixedUpdate()
        {
            Vector3 overlapCirclePosition = _groundCheckerTransform.position;
            _isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, _jumpCircleRadius, _groundMask);

            if (_gottaJump)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                _gottaJump = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _layerContact = collision.gameObject.layer;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            _layerContact = collision.gameObject.layer;
        }

        private void OnEnable()
        {
            GetComponent<PlayerInput>().Inputted += Executive;
        }

        private void OnDisable()
        {
            GetComponent<PlayerInput>().Inputted -= Executive;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_groundCheckerTransform.position, _jumpCircleRadius);
        }
    }
}
