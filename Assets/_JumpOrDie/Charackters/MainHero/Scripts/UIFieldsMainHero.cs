using UnityEngine;

namespace JumpOrDie
{
    public class UIFieldsMainHero : MonoBehaviour
    {
        [SerializeField] private HeartController _heartController;

        public HeartController HeartController { get => _heartController; }
    }
}
