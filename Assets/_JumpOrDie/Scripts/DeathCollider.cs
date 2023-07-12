using UnityEngine;

namespace JumpOrDie
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathCollider : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out TakingDamage character))
            {
                character.TakeDamage(int.MaxValue);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}