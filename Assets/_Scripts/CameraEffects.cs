using System.Collections;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 1f;
    private float _zoomWhileShaking = 0.9f;
    private float _cameraPositionZ;
    private float _cameraDefaultSize;
    private Vector3 _cameraDefaultPosition;
    private Transform _transform;
    private Camera _camera;

    private float OrthographicSize
    {
        get => _camera.orthographicSize;
        set => _camera.orthographicSize = value;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_shakeDuration < 0f)
            _shakeDuration = 0f;
    }

    private void OnEnable()
    {
        EventHolder.OnCharacterPassed += RaiseZoom;
        EventHolder.OnPlayerMistaken += RaiseShake;
    }

    private void OnDisable()
    {
        EventHolder.OnCharacterPassed -= RaiseZoom;
        EventHolder.OnPlayerMistaken -= RaiseShake;
    }

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
        _cameraDefaultPosition = _transform.position;
        _cameraDefaultSize = _camera.orthographicSize;
        _cameraPositionZ = _transform.position.z;
    }

    #endregion

    private void RaiseZoom()
    {
        // TODO: mb mojno ubrat ya podumau
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
            var shakedPosition = Random.insideUnitSphere * .9f;
            shakedPosition.z = _cameraPositionZ;
            _transform.position = shakedPosition;

            duration -= Time.deltaTime;

            yield return new WaitForSeconds(0f);
        }

        _transform.position = _cameraDefaultPosition;
        OrthographicSize = _cameraDefaultSize;
    }
}
