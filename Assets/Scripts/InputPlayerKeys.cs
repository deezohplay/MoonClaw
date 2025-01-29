using UnityEngine;

public class InputPlayerKeys : MonoBehaviour
{
    PlayerController playerController;
    private void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    public void OnLeftPressed()
    {
        playerController.HorizontalInput(-1f);
        Debug.Log("Left");
    }
    public void OnLeftReleased()
    {
        playerController.HorizontalInput(0f);
    }

    public void OnRightPressed()
    {
        playerController.HorizontalInput(1f);
    }
    public void OnRightReleased()
    {
        playerController.HorizontalInput(0f);
    }
    public void OnJump()
    {
        playerController.JumpInput();
    }
}
