using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] Transform targetpoint;
    [SerializeField] Transform player;

    bool isFirings = false;

    private void Update()
    {
        ProcessFiring();
        MoveTargetPoint();
        AimLaser();
    }

    void ProcessFiring()
    {
        var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFirings;
    }

    void MoveTargetPoint()
    {
        if (player != null)
        {
            targetpoint.position = player.position;
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
            isFirings = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFirings = false;
        }
    }


}
