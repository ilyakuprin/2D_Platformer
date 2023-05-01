using UnityEngine;

namespace Platformer2D
{
    public class EnemyFields : MonoBehaviour
    {
        [SerializeField] private GameObject _firePoint;
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;

        public GameObject FirePoint { get => _firePoint; }
        public Transform LeftPoint { get => _leftPoint; }
        public Transform RightPoint { get => _rightPoint; }
    }
}
