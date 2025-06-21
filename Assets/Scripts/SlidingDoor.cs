using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform doorLeft;
    public Transform doorRight;
    public float slideDistance = 1.5f;
    public float speed = 2f;

    private Vector3 leftClosed, rightClosed;
    private Vector3 leftOpen, rightOpen;
    private bool open = false;

    void Start()
    {
        leftClosed = doorLeft.position;
        rightClosed = doorRight.position;

        leftOpen = leftClosed + Vector3.left * slideDistance;
        rightOpen = rightClosed + Vector3.right * slideDistance;
    }

    void Update()
    {
        doorLeft.position = Vector3.Lerp(doorLeft.position, open ? leftOpen : leftClosed, Time.deltaTime * speed);
        doorRight.position = Vector3.Lerp(doorRight.position, open ? rightOpen : rightClosed, Time.deltaTime * speed);
    }

    public void OpenDoor() => open = true;
    public void CloseDoor() => open = false;
}
