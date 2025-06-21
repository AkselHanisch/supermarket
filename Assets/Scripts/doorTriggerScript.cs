using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public SlidingDoor door;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        if (other.CompareTag("Player")) door.OpenDoor();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player exited the trigger");
        if (other.CompareTag("Player")) door.CloseDoor();
    }
}
