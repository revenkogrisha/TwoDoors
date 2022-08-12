using UnityEngine;

namespace TwoDoors.Scene
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;

        private void Awake()
        {
            CheckMusicPresence();
            _music.Play();
            DontDestroyOnLoad(this);
        }

        private void CheckMusicPresence()
        {
            var musicObjects = FindObjectsOfType<BackgroundMusic>();
            foreach (var item in musicObjects)
            {
                if (item.Equals(this))
                    continue;

                Destroy(item.gameObject);
            }
        }
    }
}