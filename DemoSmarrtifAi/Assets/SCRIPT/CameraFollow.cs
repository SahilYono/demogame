using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);

    void LateUpdate()
    {
        if (player == null) return;

        // Follow position
        transform.position = player.position + offset;

        // 👇 NEW: Look in player's forward direction (but stable)
        Vector3 lookDirection = player.forward;
        lookDirection.y = 0; // prevent up/down tilt

        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }
    }
}
