using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Health))]
    public abstract class GetHealth : MonoBehaviour
    {
        private Health _health;
        protected Health Health { get { return _health; } }

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
        }
    }
}
