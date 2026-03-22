using CMProblemSolving.L1000_ScenarioToDo;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{


        [SerializeField] private Image barImage;
        [SerializeField] private enemy enemy;

    private void Start()
    {
        enemy.OnHealthAmountChanged += Enemy_OnHealthAmountChanged;
        UpdateHealthBar();

    }

    private void Enemy_OnHealthAmountChanged(object sender, System.EventArgs e)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        barImage.fillAmount = enemy.GetHealthAmount();
    }

}