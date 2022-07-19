using System;

public static class EventHolder
{
    public static event Action OnGameFinished;
    public static event Action OnGameOvered;
    public static event Action OnCharacterPassed;
    public static event Action OnPlayerMistaken;

    public static void RaiseGameFinish()
    {
        OnGameFinished?.Invoke();
    }

    public static void RaiseGameOver()
    {
        OnGameOvered?.Invoke();
    }

    public static void RaiseCharacterPassed()
    {
        OnCharacterPassed?.Invoke();
    }

    public static void RaisePlayerMistaken()
    {
        OnPlayerMistaken?.Invoke();
    }
}
