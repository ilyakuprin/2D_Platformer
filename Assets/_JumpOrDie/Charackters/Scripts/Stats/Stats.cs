using UnityEngine;

namespace JumpOrDie
{
    public abstract class Stats : MonoBehaviour
    {
        public int CurrentValue;

        [SerializeField] private int _maximumValue;
        public int MaximumValue { get { return _maximumValue; } }
    }
}
