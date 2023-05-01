using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(VisibilityZone))]
    public class LookTowardsPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _firePoint;
        private VisibilityZone _visibilityZone;

        private float _firePointX;
        private float _firePointY;
        private float _firePointZ;

        private void Awake()
        {
            _visibilityZone = GetComponent<VisibilityZone>();
            Vector3 vectorPosition = _firePoint.transform.localPosition;

            _firePointX = vectorPosition.x;
            _firePointY = vectorPosition.y;
            _firePointZ = vectorPosition.z;
        }

        private void Update()
        {
            if (_visibilityZone.SeePlayer)
            {
                if (_visibilityZone.PlayerTransform.position.x < transform.position.x)
                {
                    _firePoint.transform.localPosition = new Vector3(_firePointX, _firePointY, _firePointZ);
                    _visibilityZone.SpriteRenderer.flipX = true;
                }
                else if (_visibilityZone.PlayerTransform.position.x > transform.position.x)
                {
                    _firePoint.transform.localPosition = new Vector3(-_firePointX, _firePointY, _firePointZ);
                    _visibilityZone.SpriteRenderer.flipX = false;
                }
            }
        }
    }
}
