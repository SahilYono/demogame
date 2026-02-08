using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    [SerializeField] GameObject DestroVFX;


    ScoreBoard scoreBoard;


    void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
        
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Instantiate(DestroVFX, transform.position, Quaternion.identity);
            scoreBoard.IncreaseScore(scoreValue);
            Destroy(this.gameObject);

        }
    }
}
