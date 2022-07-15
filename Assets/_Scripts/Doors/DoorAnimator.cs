using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private bool _isCollided = false;

    private void OnMouseOver()
    {
        Open();
    }

    private void Open()
    {
        if (_isCollided)
            return;
        _isCollided = true;

        //Never do it
    }

    private void OnMouseExit()
    {
        _isCollided = false;
    }

    private void OnTriggerExit2D()
    {
        Close();
    }

    private void Close()
    {
        //Better to do it
    }
}
