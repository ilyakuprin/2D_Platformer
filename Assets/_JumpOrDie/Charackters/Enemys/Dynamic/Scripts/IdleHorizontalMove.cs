using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    public class IdleHorizontalMove : EnemyMove
    {
        [SerializeField, Range(0, 10)] private float _stopTime;

        private Coroutine _moveRight;
        private Coroutine _moveLeft;

        private void Start()
        {
            StartCoroutine(CheckSeePlayer());
        }

        private IEnumerator CheckSeePlayer()
        {
            if (!GetSpriteRender.flipX)
            {
                _moveRight = StartCoroutine(MoveRight());
            }
            else
            {
                _moveLeft = StartCoroutine(MoveLeft());
            }

            while (!VisibilityZone.SeePlayer)
            {
                yield return null;
            }
            enabled = false;

            if (_moveRight != null)
            {
                StopCoroutine(_moveRight);
            }
            if (_moveLeft != null)
            {
                StopCoroutine(_moveLeft);
            }

            while (VisibilityZone.SeePlayer)
            {
                yield return null;
            }
            enabled = true;
            StartCoroutine(CheckSeePlayer());
            yield return null;
        }

        private IEnumerator MoveRight()
        {
            horizontalForce = Speed;
            while (transform.position.x < EnemyFields.RightPoint.position.x)
            {
                yield return null;
            }
            horizontalForce = 0;
            yield return new WaitForSeconds(_stopTime);
            yield return _moveLeft = StartCoroutine(MoveLeft());
        }

        private IEnumerator MoveLeft()
        {
            horizontalForce = -Speed;
            while (transform.position.x > EnemyFields.LeftPoint.position.x)
            {
                yield return null;
            }
            horizontalForce = 0;
            yield return new WaitForSeconds(_stopTime);
            yield return _moveRight = StartCoroutine(MoveRight());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
