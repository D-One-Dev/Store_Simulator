using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //префаб покупателя
    [SerializeField] private GameObject customerPrefab;
    //минимаьная и максимальная задержки спавна покупателя
    [SerializeField] private float minCD, maxCD;
    //таймер и время до следующего спавна
    public float timer, resetTime;
    //первая точка пути
    public GameObject firstRoadPoint;
    void Start()
    {
        //получаем случайное время респавна
        resetTime = Random.Range(minCD, maxCD);
    }
    void FixedUpdate()
    {
        //счёт времени
        timer += Time.fixedDeltaTime;
        //спавн нового покупателя
        if(timer >= resetTime)
        {
            //создание нового GameObject
            GameObject newCustomer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
            //передаём покупателю первую точку маршрута
            newCustomer.GetComponent<CustomerBody>().target = firstRoadPoint;
            //получаем случайное время респавна
            resetTime = Random.Range(minCD, maxCD);
            //сбрасываем таймер
            timer = 0f;
        }
    }
}
