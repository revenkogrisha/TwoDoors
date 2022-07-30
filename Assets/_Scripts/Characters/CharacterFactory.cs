using TwoDoors.Data;
using UnityEngine;

namespace TwoDoors.Characters
{
    public abstract class CharacterFactory : MonoBehaviour
    {
       public abstract GameObject GetCharacter(CharactersId id);
    }
}
