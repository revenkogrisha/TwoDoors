using UnityEngine;

[RequireComponent(typeof(Timer))]
public class RandomDirectionMovement : ForwardMovement
{
    [SerializeField] private int _nonChangingDirectionTime;

    private float _direction = 1;
    private Timer _timer;

    #region MonoBehaviour

    private void OnEnable()
    {
        _timer = GetComponent<Timer>();
        _timer.OnCooldownPassed += TryChangeDirection;
    }

    private void OnDisable()
    {
        _timer.OnCooldownPassed -= TryChangeDirection;
    }

    #endregion

    private void TryChangeDirection()
    {
        if (_timer.TimeInSeconds < _nonChangingDirectionTime)
            return;

        switch (Random.Range(0, 2))
        {
            case 0:
                _direction *= -1;
                _speed *= _direction;
                break;
        }
    }
}
