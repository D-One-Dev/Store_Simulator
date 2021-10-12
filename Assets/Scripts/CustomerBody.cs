using UnityEngine;

public class CustomerBody : MonoBehaviour
{
    //customer move speed
    [SerializeField] private float speed;
    //customer move target
    public GameObject target;
    void Start()
    {
        //customer gets random color
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }
    void FixedUpdate()
    {
        //customer movement
        Move();
    }
    //customer movement
    private void Move()
    {
        //if there is a target
        if (target != null)
        {
            //getting smoothed move speed
            float moveX = (target.transform.position.x - transform.position.x) * 5;
            float moveY = (target.transform.position.y - transform.position.y) * 5;
            //max speed limit
            if (moveX > speed) moveX = speed;
            if (moveX < -speed) moveX = -speed;
            if (moveY > speed) moveY = speed;
            if (moveY < -speed) moveY = -speed;
            //moving the customer
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        }
    }
}
