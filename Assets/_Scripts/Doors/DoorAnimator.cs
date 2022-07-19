using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private bool _isCollided = false;

    #region MonoBehaviour

    private void OnMouseOver()
    {
        Open();
    }

    private void OnMouseExit()
    {
        _isCollided = false;
    }

    private void OnTriggerExit2D()
    {
        Close();
    }

    #endregion

    private void Open()
    {
        if (_isCollided)
            return;
        _isCollided = true;

        //Never do it
    }

    private void Close()
    {
        //Better to do it
    }
}
