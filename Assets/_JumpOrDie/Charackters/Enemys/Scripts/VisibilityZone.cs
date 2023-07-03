using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    public class VisibilityZone : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField, Range(1, 4)] private float _visibilityZoneRadius = 4;
        [SerializeField, Range(0, 180)] private float _visibilityZoneAngle = 180;
        [SerializeField, Range(0, 10)] private float _visibilityTimeUnconditional = 2;

        private Coroutine _keepFollowingPlayer;
        private Coroutine _checkVisable;
        private SpriteRenderer _spriteRenderer;
        private float _angleEnemyPlayer;
        private bool _seePlayer;

        public Transform PlayerTransform { get => _playerTransform; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        public bool SeePlayer { get => _seePlayer; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private IEnumerator CheckVisable()
        {
            while (true)
            {
                if (Vector2.Distance(transform.position, _playerTransform.position) < _visibilityZoneRadius)
                {
                    if (_spriteRenderer.flipX)
                    {
                        _angleEnemyPlayer = Vector2.Angle(Vector2.left, _playerTransform.position - transform.position);
                    }
                    else
                    {
                        _angleEnemyPlayer = Vector2.Angle(Vector2.right, _playerTransform.position - transform.position);
                    }

                    if (_angleEnemyPlayer < _visibilityZoneAngle && !_seePlayer)
                    {
                        _seePlayer = true;
                    }

                    if (_keepFollowingPlayer != null)
                    {
                        ContinueFollowWithinRadius();
                    }
                }
                else if (_seePlayer && _keepFollowingPlayer == null)
                {
                    KeepWatchingOutRadius();
                }

                yield return null;
            }
        }

        private void KeepWatchingOutRadius()
        {
            _keepFollowingPlayer = StartCoroutine(KeepFollowingPlayer());
        }

        private void ContinueFollowWithinRadius()
        {
            StopCoroutine(_keepFollowingPlayer);
            _keepFollowingPlayer = null;
        }

        private IEnumerator KeepFollowingPlayer()
        {
            yield return new WaitForSeconds(_visibilityTimeUnconditional);
            _keepFollowingPlayer = null;
            yield return _seePlayer = false;
        }

        private void OnBecameVisible()
        {
            _checkVisable = StartCoroutine(CheckVisable());
        }

        private void OnBecameInvisible()
        {
            StopCoroutine(_checkVisable);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, _visibilityZoneRadius);
        }
    }
}
