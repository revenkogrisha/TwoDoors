using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DragableObject : MonoBehaviour
{

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnMouseDrag()
    {
        SetTransformToTouchPoint();
        DisableMovementAndCollider();
    }

    private void SetTransformToTouchPoint()
    {
        Vector3 pointPosition = new(
                    Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
        var _touchPoint = Camera.main.ScreenToWorldPoint(pointPosition);
        _touchPoint.z = 0;
        _transform.position = _touchPoint;
    }

    private void DisableMovementAndCollider()
    {
        _rigidbody2D.simulated = false;
        _collider2D.enabled = false;
    }

    private void OnMouseUp()
    {
        EnableMovementAndCollider();
    }

    private void EnableMovementAndCollider()
    {
        _rigidbody2D.simulated = true;
        _collider2D.enabled = true;
    }
}
