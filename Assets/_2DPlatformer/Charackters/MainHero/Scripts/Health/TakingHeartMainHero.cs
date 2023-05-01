using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(UIFieldsMainHero))]
    public class TakingHeartMainHero : MonoBehaviour
    {
        private UIFieldsMainHero _uiFieldsMainHero;

        private void Awake()
        {
            _uiFieldsMainHero = GetComponent<UIFieldsMainHero>();
        }

        public void TakeHeart(GameObject heartGameObject)
        {
            _uiFieldsMainHero.HeartController.AddHeart(heartGameObject);
        }
    }
}
