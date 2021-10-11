using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBody : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject target;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (target != null)
        {
            float moveX = (target.transform.position.x - transform.position.x) * 5;
            float moveY = (target.transform.position.y - transform.position.y) * 5;
            if (moveX > speed) moveX = speed;
            if (moveX < -speed) moveX = -speed;
            if (moveY > speed) moveY = speed;
            if (moveY < -speed) moveY = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        }
    }
}
