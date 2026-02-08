using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerweapon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetpoint;
    [SerializeField] float targetDistance = 10f;

    bool isFiring = false;

    private void Start()
    {
        Cursor .visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLaser();
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
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetpoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLaser()
    {
        
        
            Vector3 fireDirection = targetpoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        

    }



}
