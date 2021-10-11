using UnityEngine;

public class CustomerAI : MonoBehaviour
{
    //GameObject тела покупателя
    [SerializeField] private GameObject customer;
    //минимальное и максималльное кол-во ходов покупателя
    [SerializeField] private int minMoves, maxMoves;
    //оставшееся кол-во ходов
    private int moves;
    //уходит ли покупатель из магазина
    public bool isLeaving;
    //цель движения покупателя
    public GameObject target;
    void Start()
    {
        //выдаём покупателю случайное кол-во ходов
        moves = Random.Range(minMoves, maxMoves + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //столкновение с точкой маршрута
        if(collision.gameObject.CompareTag("RoadPoint"))
        {
            //пинаем точку маршрута чтобы получить новую цель
            collision.gameObject.GetComponent<RoadPointController>().ReturnNewPoint(gameObject, isLeaving);
            //передаём новую цель телу покупателя
            customer.GetComponent<CustomerBody>().target = target;
            //уменьшаем кол-во оставшихся ходов
            moves--;
            //если ходов не осталось то покупатель уходит
            if (moves <= 0)
            {
                isLeaving = true;
            }
        }
        //столкновение с конечной точкой
        else if(collision.gameObject.CompareTag("ExitPoint"))
        {
            //удаляем GameObject покупателя
            Destroy(customer.gameObject);
        }
    }
}
