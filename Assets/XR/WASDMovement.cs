using UnityEngine;

public class XRRigKeyboardMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}
