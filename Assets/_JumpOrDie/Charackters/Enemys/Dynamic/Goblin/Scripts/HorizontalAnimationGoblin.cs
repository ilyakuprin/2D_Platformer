using System.Collections;

namespace JumpOrDie
{
    public class HorizontalAnimationGoblin : HorizontalAnimation
    {
        private void Update()
        {
            PlayAnimation();
        }

        private IEnumerator CorutinePlay()
        {
            while (true)
            {
                PlayAnimation();
                yield return null;
            }
        }
    }
}
