using UnityEngine;

public class CustomerBody : MonoBehaviour
{
    //скорость передвижения покупателя
    [SerializeField] private float speed;
    //цель движения покупателя
    public GameObject target;
    void Start()
    {
        //покупатель получает случайный цвет
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }
    void FixedUpdate()
    {
        //движение покупателя
        Move();
    }
    //движение покупателя
    private void Move()
    {
        //еси есть цель
        if (target != null)
        {
            //получаем плавную скорость движения
            float moveX = (target.transform.position.x - transform.position.x) * 5;
            float moveY = (target.transform.position.y - transform.position.y) * 5;
            //ограничиваем максимальную скорость движения
            if (moveX > speed) moveX = speed;
            if (moveX < -speed) moveX = -speed;
            if (moveY > speed) moveY = speed;
            if (moveY < -speed) moveY = -speed;
            //двигаем покупателя
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        }
    }
}
