using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    public class BackgroundMenuMotion : MonoBehaviour
    {
        [SerializeField] private float _endPointX = 1920;
        [SerializeField] private float _speed;

        private void Awake()
        {
            StartCoroutine(MoveBackground());
        }

        private IEnumerator MoveBackground()
        {
            while (true)
            {
                transform.position += Vector3.right * _speed * Time.deltaTime;

                if (transform.position.x > _endPointX)
                {
                    transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
                }

                yield return null;
            }
        }
    }
}
