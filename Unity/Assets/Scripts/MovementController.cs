using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rootBody;
    [SerializeField]
    ClimbingController climbingController;

    const float MOVE_SPEED = 5;

    void FixedUpdate()
    {
        if (climbingController.IsClimbing)
        {
            return;
        }

        var move = Vector2.zero;
        if (Keyboard.current.aKey.isPressed)
        {
            move.x--;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            move.x++;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            move.y++;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move.y--;
        }

        var pos = transform.position;
        var fwd = transform.forward;
        fwd.y = 0;
        fwd.Normalize();
        fwd *= move.y * MOVE_SPEED;

        var side = transform.right;
        side.Normalize();
        side *= move.x * MOVE_SPEED;

        var step = fwd + side;
        rootBody.MovePosition(pos + step*Time.fixedDeltaTime);
    }
}
