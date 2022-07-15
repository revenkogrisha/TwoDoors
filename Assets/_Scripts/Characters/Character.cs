using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(IMoveable))]
public class Character : MonoBehaviour
{
    public CharactersId Species;

    private bool _isTryingToPass = false;
    private IMoveable _moveable;

    public bool IsTryingToPass => _isTryingToPass;

    private void Awake()
    {
        _moveable = GetComponent<IMoveable>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _moveable.Move();
    }

    private void OnMouseUp()
    {
        StartCoroutine(TryToPass());
    }

    private IEnumerator TryToPass()
    {
        _isTryingToPass = true;

        yield return new WaitForSeconds(.1f);

        _isTryingToPass = false;
    }
}
