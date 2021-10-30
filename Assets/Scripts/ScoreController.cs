using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    //score text
    [SerializeField] private TextMeshProUGUI scoreText;
    //score
    public int score;
    //adding score
    public void AddScore()
    {
        score++;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
