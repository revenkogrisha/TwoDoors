using UnityEngine;

namespace TwoDoors.Scene
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;

        private void Awake()
        {
            _music.Play();
            DontDestroyOnLoad(this);
        }
    }
}