using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;

    TMP_Text scoreDisplay;
    private void Start() 
    {
        scoreDisplay = GetComponent<TMP_Text>();    
    }
    public void IncreaseScore(int Points)
    {
        score += Points;
        scoreDisplay.text = $"{score}";
    }

    private void Update() 
    {
        ;
    }
}
