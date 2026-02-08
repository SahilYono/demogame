using UnityEngine;
using UnityEngine.InputSystem;

public class Playerweapon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] RectTransform crosshair;

    bool isFiring = false;
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }


    public void OnFire (InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
        emmissionModule.enabled = isFiring;

    }
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;


    }

}
