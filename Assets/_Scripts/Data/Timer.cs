using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int TimeInSeconds = 0;

    [SerializeField] private int _cooldown = 2;
    private float _time = 0;
    private int _checkedTime = 0;

    public Action OnCooldownPassed;

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
