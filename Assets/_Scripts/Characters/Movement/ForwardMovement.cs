using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForwardMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody2D;

    #region MonoBehaviour

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    #endregion

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }
}
