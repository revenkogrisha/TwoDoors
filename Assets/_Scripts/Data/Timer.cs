using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action OnCooldownPassed;

    [SerializeField] private int _cooldown = 2;

    private float _time = 0;
    private int _timeInSeconds = 0;
    private int _checkedTime = 0;

    public int TimeInSeconds
    {
        get { return _timeInSeconds; }
        private set { _timeInSeconds = value; }
    }

    #region MonoBehaviour

    private void Update()
    {
        TimeInSeconds = GetTimeInSeconds();

        if (IsRightCooldown())
        {
            OnCooldownPassed?.Invoke();
            _checkedTime = TimeInSeconds;
        }
    }

    #endregion

    private int GetTimeInSeconds()
    {
        _time += Time.deltaTime;

        return Mathf.RoundToInt(_time);
    }

    private bool IsRightCooldown()
    {
        if ((TimeInSeconds % _cooldown) != 0
            || TimeInSeconds <= _checkedTime)
            return false;

        return true;
    }
}
