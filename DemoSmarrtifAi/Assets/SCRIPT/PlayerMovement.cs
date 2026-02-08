using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 4f;

    Vector2 movement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xoffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xoffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yoffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos,clampedYPos , 0f);
    }
    public void OnMove(InputValue value)
    {
       movement = value.Get<Vector2>();
    }


}
