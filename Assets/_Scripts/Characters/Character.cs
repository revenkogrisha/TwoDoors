using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(IMoveable))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharactersId _species;
    private bool _isTryingToPass = false;
    private IMoveable _moveable;

    public CharactersId Species
    {
        get
        {
            return _species;
        }
    }

    public bool IsTryingToPass => _isTryingToPass;

    #region MonoBehaviour

    private void Awake()
    {
        _moveable = GetComponent<IMoveable>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMouseUp()
    {
        StartCoroutine(TryToPass());
    }

    #endregion

    public void Move()
    {
        _moveable.Move();
    }

    private IEnumerator TryToPass()
    {
        _isTryingToPass = true;

        yield return new WaitForSeconds(.1f);

        _isTryingToPass = false;
    }
}
