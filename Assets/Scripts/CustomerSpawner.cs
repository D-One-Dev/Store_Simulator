using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //customer prefab
    [SerializeField] private GameObject customerPrefab;
    //min and max spawn cooldown
    [SerializeField] private float minCD, maxCD;
    //timer, time before next spawn
    public float timer, resetTime;
    //first road point
    public GameObject firstRoadPoint;
    void Start()
    {
        //getting random respawn time
        resetTime = Random.Range(minCD, maxCD);
    }
    void FixedUpdate()
    {
        //time count
        timer += Time.fixedDeltaTime;
        //new customer spawn
        if(timer >= resetTime)
        {
            //creating a new GameObject
            GameObject newCustomer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
            //handing the first point over to the customer
            newCustomer.GetComponent<CustomerBody>().target = firstRoadPoint;
            //getting random respawn time
            resetTime = Random.Range(minCD, maxCD);
            //timer reset
            timer = 0f;
        }
    }
}
