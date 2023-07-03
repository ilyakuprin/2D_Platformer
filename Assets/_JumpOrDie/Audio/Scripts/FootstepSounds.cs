using UnityEngine;

namespace JumpOrDie
{
    public abstract class FootstepSounds : MonoBehaviour
    {
        [SerializeField, Range(0.01f, 0.2f)] private float _circleRadius;
        [SerializeField] private LayerMask _groundMask;
        private Collider2D _groundedCollider;
        private Rigidbody2D _rigidbody;
        private bool _walksEarth;
        private readonly StringTagName _stringTagName = new StringTagName();
        private readonly float _velocityError = 0.1f;

        protected bool WalksEarth { get => _walksEarth; }
        protected string GroundedTag { get => _groundedCollider.gameObject.tag; }

        protected StringTagName TagName { get => _stringTagName; }

        protected virtual void Awake()
        {
            _rigidbody = gameObject.GetComponentInParent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            if ((_rigidbody.velocity.x > _velocityError || _rigidbody.velocity.x < -_velocityError) && 
                _rigidbody.velocity.y < _velocityError && 
                _groundedCollider)
            {
                _walksEarth = true;
            }
            else
            {
                _walksEarth = false;
            }
        }

        protected virtual void FixedUpdate()
        {
            _groundedCollider = Physics2D.OverlapCircle(transform.position, _circleRadius, _groundMask);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _circleRadius);
        }
    }
}
