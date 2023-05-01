using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(EnemyFields), typeof(Rigidbody2D), typeof(VisibilityZone))]
    public abstract class EnemyMove : MonoBehaviour
    {
        protected float horizontalForce;

        [SerializeField, Range(0.1f, 10)] private float _speed;
        private Rigidbody2D _rigidbody;
        private HorizontalAnimation _horizontalAnimation;
        private EnemyFields _enemyFields;
        private VisibilityZone _visibilityZone;
        private SpriteRenderer _spriteRenderer;

        protected float Speed { get => _speed; }
        protected EnemyFields EnemyFields { get => _enemyFields; }
        protected VisibilityZone VisibilityZone { get => _visibilityZone; }
        protected SpriteRenderer GetSpriteRender { get => _spriteRenderer; }

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemyFields = GetComponent<EnemyFields>();
            _visibilityZone = GetComponent<VisibilityZone>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            float speedError = 0.01f;
            _rigidbody = GetComponent<Rigidbody2D>();
            _horizontalAnimation = new HorizontalAnimation(
                GetComponent<SpriteRenderer>(),
                GetComponent<Animator>(),
                _rigidbody,
                speedError,
                _enemyFields.FirePoint);
        }

        protected virtual void Update()
        {
            _horizontalAnimation.PlayAnimation();
        }

        protected virtual void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(horizontalForce, _rigidbody.velocity.y);
        }
    }
}
