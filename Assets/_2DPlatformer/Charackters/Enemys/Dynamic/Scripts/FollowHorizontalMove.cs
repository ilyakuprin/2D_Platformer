using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    public class FollowHorizontalMove : EnemyMove
    {
        private Coroutine _followPlayer;

        private float _distanceBetweenEnemyAndHisFirepoint;

        private void Start()
        {
            _distanceBetweenEnemyAndHisFirepoint = 
                Mathf.Abs(transform.position.x - EnemyFields.FirePoint.transform.position.x);
            StartCoroutine(CheckSeePlayer());
        }

        private IEnumerator CheckSeePlayer()
        {
            enabled = false;
            while (!VisibilityZone.SeePlayer)
            {
                yield return null;
            }

            enabled = true;
            _followPlayer = StartCoroutine(FollowPlayer());
            while (VisibilityZone.SeePlayer)
            {
                yield return null;
            }

            StopCoroutine(_followPlayer);
            StartCoroutine(CheckSeePlayer());
            yield return null;
        }

        private IEnumerator FollowPlayer()
        {
            while (true) 
            {
                bool goAndStayFarRight = !GetSpriteRender.flipX && 
                    transform.position.x > EnemyFields.RightPoint.position.x && 
                    VisibilityZone.PlayerTransform.position.x > transform.position.x;
                bool goAndStayFarLeft = GetSpriteRender.flipX && 
                    transform.position.x < EnemyFields.LeftPoint.position.x &&
                    VisibilityZone.PlayerTransform.position.x < transform.position.x;
                bool distanceBetweenEnemyFirePointAndPlayer = 
                    (Mathf.Abs(transform.position.x - VisibilityZone.PlayerTransform.position.x)) < 
                    _distanceBetweenEnemyAndHisFirepoint;

                if (goAndStayFarRight || goAndStayFarLeft || distanceBetweenEnemyFirePointAndPlayer)
                {
                    horizontalForce = 0;
                }
                else if (VisibilityZone.PlayerTransform.position.x < transform.position.x)
                {
                    horizontalForce = -Speed;
                }
                else if (VisibilityZone.PlayerTransform.position.x >= transform.position.x)
                {
                    horizontalForce = Speed;
                }                
                yield return null;
            }
        }
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
