using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    //gameover text, hp text
    [SerializeField] private TextMeshProUGUI healthTxt;
    [SerializeField] private GameObject gameOverPanel;
    //amount of hp
    private int health = 3;
    //hp loose
    public void LooseHp()
    {
        //decreasing hp
        health -= 1;
        //refreshing the text
        healthTxt.text = "HEALTH: " + health.ToString();
        //death
        if(health == 0)
        {
            //disabling player's logic
            gameObject.GetComponent<PlayerController>().isAlive = false;
            //freezing the game
            Time.timeScale = 0f;
            //showing gameover text
            gameOverPanel.SetActive(true);
        }
    }
}
