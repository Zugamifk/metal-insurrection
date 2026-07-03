using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rootBody;
    [SerializeField]
    float jumpPower;

    public bool isGrounded { get; private set; } = true;
    private void OnTriggerStay(Collider other)
    {
        if((LayerMask.NameToLayer("Ground") & other.gameObject.layer) > 0)
        {
            isGrounded = true;
        } 
    }

    private void FixedUpdate()
    {
        if(isGrounded && Keyboard.current.spaceKey.isPressed)
        {
            rootBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        isGrounded = false;
    }
}
