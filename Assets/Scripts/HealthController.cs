using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    //текст поражения, текст с хп
    [SerializeField] private Text gameOver, healthTxt;
    //кол-во хп
    private int health = 3;
    //потеря хп
    public void LooseHp()
    {
        //отнимаем хп
        health -= 1;
        //меняем текст
        healthTxt.text = "Health: " + health.ToString();
        //смерть
        if (health == 0)
        {
            //отключаем логику игрока
            gameObject.GetComponent<PlayerController>().isAlive = false;
            //сбрасываем игроку velocity чтобы он не етал по карте (не помогает)
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //показываем текст поражения
            gameOver.enabled = true;
        }
    }
}
