using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool IsOnGround { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOnGround = false;
    }
}