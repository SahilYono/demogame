using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform player;

    private Vector3 playerStartPos;
    private Vector3 cameraStartPos;

    private float playerStartYRot;
    private float cameraStartXRot;

    void Start()
    {
        // Store initial positions
        playerStartPos = player.position;
        cameraStartPos = transform.position;

        // Store initial rotations
        playerStartYRot = player.eulerAngles.y;
        cameraStartXRot = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // ---- POSITION DELTA ----
        Vector3 positionDelta = player.position - playerStartPos;
        transform.position = cameraStartPos + positionDelta;

        // ---- ROTATION DELTA (ONLY Y) ----
        float currentPlayerY = player.eulerAngles.y;
        float deltaY = currentPlayerY - playerStartYRot;

        float finalY = deltaY;

        // Keep X fixed, Z always 0
        transform.rotation = Quaternion.Euler(cameraStartXRot, finalY, 0f);
    }
}
