using UnityEngine;

public class moveHead : MonoBehaviour
{
    public Transform player;
    public Transform head;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Head rotated towards player
        head.LookAt(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Head rotated towards player
        head.LookAt(player.position);
    }
}
