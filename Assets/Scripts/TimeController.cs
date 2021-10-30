using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    //time text, score text, highscore text
    [SerializeField] private TextMeshProUGUI timeText, scoreText, highscoreText;
    //how many seconds are in one game minute, hour of game end
    [SerializeField] private float secondsForOneMinute, endTimeHour;
    //UI GameObject, GAMEWIN GameObject
    [SerializeField] private GameObject UI, GAMEWIN;
    //current time
    private float currentTime;
    //game hours, game minutes
    private int gameTimeHours = 8, gameTimeMinutes = 0;
    //is game won
    public bool isGameWon;
    void FixedUpdate()
    {
        if (!isGameWon)
        {
            //adding time
            currentTime += Time.fixedDeltaTime;
            if(currentTime >= secondsForOneMinute)
            {
                //add minutes
                gameTimeMinutes++;
                //add hours
                if(gameTimeMinutes >= 60)
                {
                    gameTimeHours++;
                    gameTimeMinutes = 0;
                }
                ///refreshing the text
                if(gameTimeMinutes < 10) timeText.text = "TIME: " + gameTimeHours.ToString() + ":0" + gameTimeMinutes.ToString();
                else timeText.text = "TIME: " + gameTimeHours.ToString() + ":" + gameTimeMinutes.ToString();
                currentTime = 0f;
            }
            //game win
            if(gameTimeHours >= endTimeHour) WinGame();
        }
    }
    private void WinGame()
    {
        //pause the game
        Time.timeScale = 0f;
        isGameWon = true;
        //show win text
        UI.SetActive(false);
        GAMEWIN.SetActive(true);
        //show score
        int score = gameObject.GetComponent<ScoreController>().score;
        scoreText.text = "SCORE: " + score.ToString();
        //show highscore
        if (score > PlayerPrefs.GetInt("highscore", 0)) PlayerPrefs.SetInt("highscore", score);
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore", score).ToString();
    }
}
