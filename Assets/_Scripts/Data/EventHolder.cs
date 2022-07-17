using System;

public static class EventHolder
{
    public static event Action OnGameFinished;
    public static event Action OnGameOvered;

    public static void RaiseGameFinish()
    {
        OnGameFinished?.Invoke();
    }

    public static void RaiseGameOver()
    {
        OnGameOvered?.Invoke();
    }
}
