using UnityEngine;

public class CustomerAI : MonoBehaviour
{
    //player's body GameObject
    [SerializeField] private GameObject customer;
    //min and max amount of customer's moves
    [SerializeField] private int minMoves, maxMoves;
    //moves remained
    private int moves;
    //is customer leaving the shop
    public bool isLeaving;
    //customer's move target
    public GameObject target;
    void Start()
    {
        //get a random amount of moves
        moves = Random.Range(minMoves, maxMoves + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //road point collision
        if(collision.gameObject.CompareTag("RoadPoint"))
        {
            //getting a new road point
            collision.gameObject.GetComponent<RoadPointController>().ReturnNewPoint(gameObject, isLeaving);
            //hand a new road point over to customer's body
            customer.GetComponent<CustomerBody>().target = target;
            //decreasing the amount of moves left
            moves--;
            //if there are no more moves the customer leaves
            if (moves <= 0)
            {
                isLeaving = true;
            }
        }
        //end point collision
        else if(collision.gameObject.CompareTag("ExitPoint"))
        {
            //deleting customer GameObject
            Destroy(customer.gameObject);
        }
    }
}
