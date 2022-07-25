using System.Collections;
using TwoDoors.Data;
using UnityEngine;

namespace TwoDoors.Scene
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private float _shakeDuration = 1f;
        [SerializeField] private float _shakeForce = 0.9f;
        [SerializeField] private ParticleSystem _firework;

        private float _zoomWhileShaking = 0.9f;
        private float _cameraDefaultSize;
        private Vector3 _cameraDefaultPosition;

        private float OrthographicSize
        {
            get => Camera.main.orthographicSize;
            set => Camera.main.orthographicSize = value;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            if (_shakeDuration < 0f)
                _shakeDuration = 0f;

            if (_shakeForce > 1f)
                _shakeForce = 1f;
            else if (_shakeForce < 0f)
                _shakeForce = 0f;
        }

        private void OnEnable()
        {
            EventHolder.OnCharacterPassed += RaiseParticles;
            EventHolder.OnPlayerMistaken += RaiseShake;
        }

        private void OnDisable()
        {
            EventHolder.OnCharacterPassed -= RaiseParticles;
            EventHolder.OnPlayerMistaken -= RaiseShake;
        }

        private void Awake()
        {
            _cameraDefaultPosition = transform.position;
            _cameraDefaultSize = Camera.main.orthographicSize;
        }

        #endregion

        private void RaiseParticles()
        {
            _firework.Play();
        }

        private void RaiseShake()
        {
            StartCoroutine(DoRandomShake());
        }

        private IEnumerator DoRandomShake()
        {
            var duration = _shakeDuration;
            OrthographicSize *= _zoomWhileShaking;

            while (duration > 0)
            {
                var shakedPosition = Random.insideUnitSphere * _shakeForce;
                shakedPosition.z = _cameraDefaultPosition.z;
                transform.position = shakedPosition;

                duration -= Time.deltaTime;

                yield return null;
            }

            transform.position = _cameraDefaultPosition;
            OrthographicSize = _cameraDefaultSize;
        }
    }
}
