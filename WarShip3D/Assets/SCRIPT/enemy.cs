using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] int healthAmount = 3;
    [SerializeField] int scoreValue = 10;
    [SerializeField] GameObject DestroVFX;
    [SerializeField] int healAmountMax = 1;


    ScoreBoard scoreBoard;

    public event EventHandler OnHealthAmountChanged;

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
        //healthAmount--;
       /* if (healthAmount <= 0)
        {
            Instantiate(DestroVFX, transform.position, Quaternion.identity);
            scoreBoard.IncreaseScore(scoreValue);
            Destroy(this.gameObject);

        }*/
                damage(1);
        Debug.Log("Damage"+ healthAmount); 
    }

    public void damage(int damageAmount)
    {
        healthAmount-= damageAmount;
        if (healthAmount <= 0)
        {
            Instantiate(DestroVFX, transform.position, Quaternion.identity);
            scoreBoard.IncreaseScore(scoreValue);
            Destroy(this.gameObject);
            healthAmount = 0;
        }
        OnHealthAmountChanged?.Invoke(this, EventArgs.Empty);
    }
    //FOR FURTHER IMPLEMENTATION OF HEALING SYSTEM

    /*public void heal(int healAmount)
    {
        healthAmount += healAmount;
        if(healthAmount> healAmountMax)
        {
            healAmount = healAmountMax;
        }
    }*/

    public float GetHealthAmount()
    {
        return (float)healthAmount / healAmountMax;
    }

}
