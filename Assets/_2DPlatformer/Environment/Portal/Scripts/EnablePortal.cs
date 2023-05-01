using UnityEngine;

namespace Platformer2D
{
    public class EnablePortal : MonoBehaviour
    {
        [SerializeField] private Behaviour[] _behaviors;
        private readonly HashLayers _layers = new HashLayers();
        private Collider2D _collision;

        private void Awake()
        {
            IterateOverArray(false);
        }

        private void Update()
        {
            if (_collision?.gameObject.layer == _layers.Player)
            {
                IterateOverArray(true);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _collision = collision;
        }

        private void IterateOverArray(bool state)
        {
            for (int i = 0; i < _behaviors.Length; i++)
            {
                _behaviors[i].enabled = state;
            }
        }
    }
}
