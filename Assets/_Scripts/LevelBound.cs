using UnityEngine;

public class LevelBound : MonoBehaviour
{
    [SerializeField] private GameState _game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;
        CharacterPassedAway(other);
    }

    private void CharacterPassedAway(GameObject characterObject)
    {
        Destroy(characterObject);
        _game.SubtractScore();
    }
}
