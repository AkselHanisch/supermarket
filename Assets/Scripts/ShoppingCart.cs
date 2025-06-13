// using UnityEngine;

// public class ShoppingCart : MonoBehaviour
// {
//     public float pushForce = 100f; // Force applied when pushing
//     public float rotationSpeed = 100f; // Wheel rotation speed for visual effect
//     public Transform[] wheels; // Assign wheel GameObjects in Inspector
//     private Rigidbody rb;
//     private bool isPlayerNear = false;
//     private Camera mainCamera; // Use main camera instead of player transform

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         mainCamera = Camera.main; // Get the main camera
//     }

//     void Update()
//     {
//         if (isPlayerNear && Input.GetKey(KeyCode.E))
//         {
//             Debug.Log("Pushing cart - isPlayerNear: " + isPlayerNear + ", E pressed: " + Input.GetKey(KeyCode.E));
//             Vector3 pushDirection = mainCamera.transform.forward;
//             pushDirection.y = 0; // Keep force horizontal
//             rb.AddForce(pushDirection * pushForce * Time.deltaTime);

//             // Rotate wheels visually based on cart velocity
//             float wheelRotation = rb.linearVelocity.magnitude * rotationSpeed * Time.deltaTime;
//             foreach (Transform wheel in wheels)
//             {
//                 wheel.Rotate(Vector3.right, wheelRotation); // Adjust axis if needed
//             }
//         }
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         Debug.Log("Player entered trigger");
//         if (other.CompareTag("Player"))
//         {
//             isPlayerNear = true;
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         Debug.Log("Player exited trigger");
//         if (other.CompareTag("Player"))
//         {
//             isPlayerNear = false;
//         }
//     }
// }