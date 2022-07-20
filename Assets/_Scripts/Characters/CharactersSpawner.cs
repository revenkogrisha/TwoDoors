using UnityEngine;

public class CharactersSpawner : MonoBehaviour
{
    public GameObject[] CharactersInGame;

    [SerializeField] private int _defaultSpawnCooldown = 2;
    private float _time = 0;
    private int _checkedTime = 0;

    #region MonoBehaviour

    void Update()
    {
        int timeInSeconds = GetTimeInSeconds();
        CheckCooldownAndSpawn(timeInSeconds);
    }

    #endregion

    private int GetTimeInSeconds()
    {
        _time += Time.deltaTime;
        return Mathf.RoundToInt(_time);
    }

    private void CheckCooldownAndSpawn(int timeInSeconds)
    {
        if ((timeInSeconds % _defaultSpawnCooldown) != 0) return;
        if (timeInSeconds <= _checkedTime) return;
        _checkedTime = timeInSeconds;
        SpawnRandomCharacterFromList();
    }

    private void SpawnRandomCharacterFromList()
    {
        int index = Random.Range(0, CharactersInGame.Length);
        Instantiate(CharactersInGame[index]);
    }
}
