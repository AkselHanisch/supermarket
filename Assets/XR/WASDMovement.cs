using UnityEngine;

public class XRRigKeyboardMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float turnSpeed = 60f;

    void Update()
    {
        // Movement - Left Joystick or Keyboard
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left Stick X
        float moveZ = Input.GetAxis("Vertical");   // W/S or Left Stick Y
        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);

        // Turning - Right Joystick X axis
        float turn = Input.GetAxis("JoystickRightX"); // We'll map this below
        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);
    }
}
