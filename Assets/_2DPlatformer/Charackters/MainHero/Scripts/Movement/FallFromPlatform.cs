using System.Collections;
using UnityEngine;

namespace Platformer2D
{
    public class FallFromPlatform : MonoBehaviour, IMainHeroAction
    {
        private readonly HashLayers _hashLayers = new HashLayers();
        private Collision2D _collision2D;
        private GameObject _platformWithEffector2D;
        private Coroutine _waitAssignNativeLayer;
        private int _nativeLayerPlatform;
        private bool _pressDown;

        private void Start()
        {
            _pressDown = false;
        }

        public void Executive(InputData inputData)
        {
            if (inputData.VerticalDirection < 0 && !_pressDown &&
                _collision2D.enabled && _collision2D.gameObject.TryGetComponent(out PlatformEffector2D _platformEffector2D))
            {
                if (_platformEffector2D.useOneWay)
                {
                    _platformWithEffector2D = _collision2D.gameObject;
                    _nativeLayerPlatform = _platformWithEffector2D.layer;
                    _platformWithEffector2D.layer = _hashLayers.GroundAfterJumpingDown;

                    _pressDown = true;
                    _waitAssignNativeLayer = StartCoroutine(WaitAssignNativeLayer());
                }
            }

            if (inputData.Jump && _waitAssignNativeLayer != null)
            {
                StopCoroutine(_waitAssignNativeLayer);
                AssignNativeLayer();
            }
        }

        private IEnumerator WaitAssignNativeLayer()
        {
            var platformPositionY = _platformWithEffector2D?.transform.position.y + 
                                    _platformWithEffector2D?.gameObject.GetComponent<Collider2D>().offset.y;

            while (transform.position.y > platformPositionY)
            {
                yield return null;
            }

            AssignNativeLayer();
            yield return null;
        }

        private void AssignNativeLayer()
        {
            if (_platformWithEffector2D != null)
            {
                _platformWithEffector2D.layer = _nativeLayerPlatform;
                _platformWithEffector2D = null;
                _waitAssignNativeLayer = null;
            }

            _pressDown = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _collision2D = collision;
        }

        private void OnEnable()
        {
            GetComponent<PlayerInput>().Inputted += Executive;
        }

        private void OnDisable()
        {
            GetComponent<PlayerInput>().Inputted -= Executive;
        }
    }
}
