using System;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameState _game;
    private readonly DoorsId DoorId;
    private readonly List<CharactersId> CharactersWhoPasses;
    private Character _character;


    private void OnTriggerEnter2D(Collider2D other)
    {
        _character = other.GetComponent<Character>();
        CheckCharacter();
    }

    private void CheckCharacter()
    {
        if (_character == null)
            throw new Exception("Character is null!");
        if (!_character.IsTryingToPass)
            return;
        if (CharactersWhoPasses.Contains(_character.Race))
        {
            CharacterPassed();
            return;
        }
        CharacterDidNotPass();
    }

    private void CharacterPassed()
    {
        Destroy(_character.gameObject);
        _game.AddScore();
    }

    private void CharacterDidNotPass()
    {
        Destroy(_character.gameObject);
        _game.SubtractScore();
    }
}

