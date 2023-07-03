using UnityEngine;

namespace JumpOrDie
{
    public class DeathCanvas : MonoBehaviour
    {
        private void OnEnable()
        {
            Cursor.visible = true;
        }

        private void OnDisable()
        {
            Cursor.visible = false;
        }
    }
}
