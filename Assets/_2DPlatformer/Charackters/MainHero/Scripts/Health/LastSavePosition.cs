using UnityEngine;

namespace Platformer2D
{
    public class LastSavePosition : MonoBehaviour
    {
        [HideInInspector] public Vector3 SavePosition;

        private void Awake()
        {
            SavePosition = transform.position;
        }
    }
}
