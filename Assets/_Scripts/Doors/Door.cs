using System;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorsId _doorId;
    [SerializeField] private GameState _game;
    [SerializeField] private List<CharactersId> _charactersWhoPasses;
    private Character _character;

    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D other)
    {
        _character = other.GetComponent<Character>();

        if (_character == null)
            throw new Exception("Character is null!");

        if (!_character.IsTryingToPass)
            return;

        TryPassCharacter();
    }

    #endregion

    private void TryPassCharacter()
    {
        if (_charactersWhoPasses.Contains(_character.Species))
        {
            PassCharacter();
            return;
        }

        SubtractScore();
    }

    private void PassCharacter()
    {
        Destroy(_character.gameObject);
        _game.AddScore();
    }

    private void SubtractScore()
    {
        Destroy(_character.gameObject);
        _game.SubtractScore();
    }
}

