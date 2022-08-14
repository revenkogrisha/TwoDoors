using UnityEngine;

namespace TwoDoors.Characters
{
    public class CharacterAudio : INonMonoEventSubscriber
    {
        private DragableObject _dragable;
        private AudioSource _dragSound;

        public CharacterAudio(DragableObject dragable, AudioSource dragSound)
        {
            _dragable = dragable;
            _dragSound = dragSound;

            _dragable.OnDragStarted += PlayDragSound;
        }

        public void Disable() => _dragable.OnDragStarted -= PlayDragSound;

        private void PlayDragSound() => _dragSound.Play();
    }
}