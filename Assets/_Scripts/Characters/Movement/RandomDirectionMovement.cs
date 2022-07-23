using UnityEngine;

[RequireComponent(typeof(Timer))]
public class RandomDirectionMovement : ForwardMovement
{
    [SerializeField] private int _nonChangingDirectionTime = 2;

    protected Timer _timer;
    private float _direction = 1;

    #region MonoBehaviour

    private void Awake()
    {
        base.Awake();
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
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

        if (Random.Range(0, 2) == 0)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _direction *= -1;
        _speed *= _direction;
    }
}
