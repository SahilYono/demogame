using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Destroy(this.gameObject);

        }
    }
}
