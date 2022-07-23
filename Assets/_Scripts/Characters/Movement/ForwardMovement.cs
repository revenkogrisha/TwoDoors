using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForwardMovement : MonoBehaviour, IMoveable
{
    [SerializeField] protected float _speed;

    protected Rigidbody2D _rigidbody2D;

    #region MonoBehaviour

    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    #endregion

    public virtual void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }
}
