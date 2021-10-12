using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    //gameover text, hp text
    [SerializeField] private Text gameOver, healthTxt;
    //amount of hp
    private int health = 3;
    //hp loose
    public void LooseHp()
    {
        //decreasing hp
        health -= 1;
        //refreshing the text
        healthTxt.text = "Health: " + health.ToString();
        //death
        if (health == 0)
        {
            //disabling player's logic
            gameObject.GetComponent<PlayerController>().isAlive = false;
            //resetting player's velocity so he doesn't fly around the map (not working)
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //showing gameover text
            gameOver.enabled = true;
        }
    }
}
