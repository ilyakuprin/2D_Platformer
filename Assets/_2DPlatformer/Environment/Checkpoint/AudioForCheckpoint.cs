using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(CheckPointManager))]
    public class AudioForCheckpoint : OneShotAudioForTriggerWithoutDel
    {
        private CheckPointManager _checkPointManager;

        protected override void Awake()
        {
            base.Awake();

            _checkPointManager = GetComponent<CheckPointManager>();
        }

        private void OnEnable()
        {
            _checkPointManager.SavingHappened += PlayAudio;
        }

        private void OnDisable()
        {
            _checkPointManager.SavingHappened -= PlayAudio;
        }
    }
}
