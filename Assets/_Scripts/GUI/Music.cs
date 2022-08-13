using TwoDoors.Save;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace TwoDoors.GUI
{
    public class Music : MonoBehaviour
    {
        private const string MusicVolume = nameof(MusicVolume);

        [SerializeField] private AudioMixerGroup _mixer;
        [SerializeField] private Slider _slider;

        [Inject] private SaveService _saveService;

        #region MonoBehaviour

        private void Start()
        {
            var volume = _saveService.MusicVolume;
            SetMusicVolume(volume);

            _slider.value = volume;
            _slider.onValueChanged.AddListener(SetMusicVolume);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(SetMusicVolume);
        }

        #endregion

        private void SetMusicVolume(float volume)
        {
            _mixer.audioMixer.SetFloat(MusicVolume, volume);
        }
    }
}
