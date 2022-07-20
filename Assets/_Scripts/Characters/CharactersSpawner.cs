using UnityEngine;

public class CharactersSpawner : MonoBehaviour
{
    public GameObject[] CharactersInGame;

    [SerializeField] private int _defaultSpawnCooldown = 2;
    private float _time = 0;
    private int _timeInSeconds = 0;
    private int _checkedTime = 0;

    #region MonoBehaviour

    void Update()
    {
        _timeInSeconds = GetTimeInSeconds();

        if (IsRightCooldown())
        {
            SpawnRandomCharacter();
            _checkedTime = _timeInSeconds;
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
        if ((_timeInSeconds % _defaultSpawnCooldown) != 0
            || _timeInSeconds <= _checkedTime)
            return false;

        return true;
    }

    private void SpawnRandomCharacter()
    {
        int index = Random.Range(0, CharactersInGame.Length);
        Instantiate(CharactersInGame[index]);
    }
}
