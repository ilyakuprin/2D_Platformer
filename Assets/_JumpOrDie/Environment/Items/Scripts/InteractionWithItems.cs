using System.Collections;
using UnityEngine;

namespace JumpOrDie
{
    public abstract class InteractionWithItems : MonoBehaviour
    {
        private readonly HashLayers _hashLayers = new HashLayers();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            StartCoroutine(CheckLayer(collision));
        }

        private IEnumerator CheckLayer(Collider2D collision)
        {
            if (collision.gameObject.layer == _hashLayers.Player)
            {
                MakeAction(collision.gameObject);
            }

            yield return null;
        }

        protected abstract void MakeAction(GameObject player);
    }
}
