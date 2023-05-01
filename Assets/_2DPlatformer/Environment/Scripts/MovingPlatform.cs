using System.Collections;
using UnityEngine;

namespace Environment
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;
        [SerializeField] private float _speed;

        private void Start()
        {
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (transform.position.x < _rightPoint.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, _rightPoint.position, _speed * Time.deltaTime);
                yield return null;
            }

            while (transform.position.x > _leftPoint.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, _leftPoint.position, _speed * Time.deltaTime);
                yield return null;
            }

            yield return StartCoroutine(Move());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.transform.SetParent(transform);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            collision.transform.SetParent(null);
        }
    }
}
