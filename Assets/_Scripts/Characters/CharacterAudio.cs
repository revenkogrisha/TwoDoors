using UnityEngine;

namespace TwoDoors.Characters
{
    public class CharacterAudio
    {
        private DragableObject _dragable;
        private AudioSource _dragSound;
        private AudioSource _mouseUpSound;

        public CharacterAudio(DragableObject dragable, AudioSource dragSound, AudioSource mouseUpSound)
        {
            _dragable = dragable;
            _dragSound = dragSound;
            _mouseUpSound = mouseUpSound;

            _dragable.OnDragStarted += PlayDragSound;
            _dragable.OnDragStopped += PlayMouseUpSound;
        }

        public void Disable()
        {
            _dragable.OnDragStarted -= PlayDragSound;
            _dragable.OnDragStopped -= PlayMouseUpSound;
        }

        private void PlayDragSound()
        {
            _dragSound.Play();
        }

        private void PlayMouseUpSound() => _mouseUpSound.Play();
    }
}