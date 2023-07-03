using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    public class CheckPointManager : MonoBehaviour
    {
        public delegate void InteractWithPlayer();
        public event InteractWithPlayer SavingHappened;

        private readonly HashLayers _hashLayers = new HashLayers();
        private Collider2D _collider;
        private Collider2D _triggerColliderGameObj;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            StartCoroutine(CheckAndStartAction());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _triggerColliderGameObj = collision;
        }

        private IEnumerator CheckAndStartAction()
        {
            while (true)
            {
                var triggerGameObj = _triggerColliderGameObj?.gameObject;

                if (triggerGameObj == null)
                {
                    yield return null;
                }
                else if (triggerGameObj.layer == _hashLayers.Player &&
                    triggerGameObj.TryGetComponent(out LastSavePosition lastSavePosition))
                {
                    SavePosition(lastSavePosition);

                    SavingHappened?.Invoke();
                    break;
                }
                yield return null;
            }
        }

        private void SavePosition(LastSavePosition lastSavePosition)
        {
            lastSavePosition.SavePosition = transform.position;
            _collider.enabled = false;
        }
    }
}
