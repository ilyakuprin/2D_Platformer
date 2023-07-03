using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JumpOrDie
{
    public class MoveToNextLevel
    {
        private Vector3 _finalSize = new Vector3(0.1f, 0.1f, 0.1f);
        private readonly float _decreaseTime = 3f;

        public IEnumerator ReduceAndLoad(GameObject player, int nextSceneNumber)
        {
            player.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            while (player.transform.localScale.x > _finalSize.x)
            {
                player.transform.localScale = Vector3.Lerp(player.transform.localScale, Vector3.zero, Time.deltaTime * _decreaseTime);
                yield return null;
            }

            SceneManager.LoadScene(nextSceneNumber);
            yield return null;
        }
    }
}
