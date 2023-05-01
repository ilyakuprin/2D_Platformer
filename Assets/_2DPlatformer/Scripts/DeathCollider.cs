using UnityEngine;

namespace Platformer2D
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
            if (collision.gameObject.TryGetComponent(out DeathMainHero mainHero))
            {
                mainHero.Die();
            }
            else if (collision.gameObject.TryGetComponent(out DeathEnemy enemy))
            {
                enemy.Die();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}