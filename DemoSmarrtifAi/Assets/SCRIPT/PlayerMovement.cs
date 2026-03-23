using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 4f;

    [SerializeField] float controlRollFactor = 10f;

    Vector2 movement;

    float startTime;

    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        if (Time.time < startTime + 5f) return;
        PlayerMove();
        ProcessRotation();
    }

    void PlayerMove()
    {
        float xoffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xoffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yoffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(controlRollFactor * movement.y, 0f, -controlRollFactor*movement.x);
        transform.localRotation = targetRotation;
    }
}
