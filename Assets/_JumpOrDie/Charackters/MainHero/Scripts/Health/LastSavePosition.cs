using UnityEngine;

namespace JumpOrDie
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
