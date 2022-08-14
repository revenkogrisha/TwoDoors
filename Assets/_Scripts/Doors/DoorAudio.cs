using TwoDoors.Scene;
using UnityEngine;

namespace TwoDoors.Doors
{
    public class DoorAudio : INonMonoEventSubscriber
    {
        private Score _score;
        private AudioSource _successSound;
        private AudioSource _failSound;
        
        public DoorAudio(AudioSource successSound, AudioSource failSound, Score score)
        {
            _successSound = successSound;
            _failSound = failSound;
            _score = score;

            if (_score is LevelScore levelScore)
            {
                levelScore.OnPlayerFailed += PlayFailSound;

            }

            _score.OnPlayerScored += PlaySuccessSound;
        }

        public void Disable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnPlayerFailed -= PlayFailSound;

            _score.OnPlayerScored -= PlaySuccessSound;
        }

        private void PlaySuccessSound() => _successSound.Play();

        private void PlayFailSound() => _failSound.Play();
    }
}