using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] Transform targetpoint;
    [SerializeField] Transform player;
    [SerializeField] float leadAmount = 2f; // Adjust this to lead the shot

    bool isFiring = false;
    private Vector3 lastPlayerPosition;
    private Vector3 playerVelocity;

    private void Start()
    {
        if (player != null)
        {
            lastPlayerPosition = player.position;
        }
    }

    private void Update()
    {
        CalculatePlayerVelocity();
        ProcessFiring();
        MoveTargetPoint();
        AimLaser();
    }

    void CalculatePlayerVelocity()
    {
        if (player != null)
        {
            playerVelocity = (player.position - lastPlayerPosition) / Time.deltaTime;
            lastPlayerPosition = player.position;
        }
    }

    void ProcessFiring()
    {
        var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFiring;
    }

    void MoveTargetPoint()
    {
        if (player != null)
        {
            // Predict where the player will be
            Vector3 predictedPosition = player.position + (playerVelocity * leadAmount);
            targetpoint.position = predictedPosition;
        }
    }

    void AimLaser()
    {
        Vector3 fireDirection = targetpoint.position - this.transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
        laser.transform.rotation = rotationToTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFiring = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFiring = false;
        }

    }


}
