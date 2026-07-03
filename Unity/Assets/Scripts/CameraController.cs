using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    const float SENSITIVITY = 25;

    void Update()
    {
        var angles = transform.parent.localEulerAngles;
        var move = Mouse.current.delta.ReadValue();
        angles.y += move.x * SENSITIVITY * Time.deltaTime;
        transform.parent.localEulerAngles = angles;

        angles = transform.localEulerAngles;
        angles.x -= move.y * SENSITIVITY * Time.deltaTime;
        if(angles.x > 180)
        {
            angles.x = Mathf.Max(angles.x, 270);
        } else
        {
            angles.x = Mathf.Min(angles.x, 90);
        }
        transform.localEulerAngles = angles;
    }
}
