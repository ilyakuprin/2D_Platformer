using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    public class Cutscene1 : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _finishPoint;
        [SerializeField, Range(1, 3)] private float _speed;
        [SerializeField, Range(0.5f, 5)] private float _waintTime;

        private void Awake()
        {
            _playerInput.enabled = false;
        }

        private void Start()
        {
            StartCoroutine(MoveToFinish());
        }

        private IEnumerator MoveToFinish()
        {
            var wait = new WaitForSeconds(_waintTime);

            yield return wait;

            while (transform.position.x != _finishPoint.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, _finishPoint.position, _speed * Time.deltaTime);
                yield return null;
            }

            yield return wait;

            _playerInput.enabled = true;
            Destroy(_finishPoint.gameObject);
            Destroy(gameObject);
        }
    }
}
