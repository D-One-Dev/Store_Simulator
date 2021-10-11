using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAI : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    [SerializeField] private int minMoves, maxMoves;
    private int moves;
    public bool isLeaving;
    public GameObject target;
    void Start()
    {
        moves = Random.Range(minMoves, maxMoves + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RoadPoint"))
        {
            collision.gameObject.GetComponent<RoadPointController>().ReturnNewPoint(gameObject, isLeaving);
            customer.GetComponent<CustomerBody>().target = target;
            moves--;
            if (moves <= 0)
            {
                isLeaving = true;
            }
        }
        else if(collision.gameObject.CompareTag("ExitPoint"))
        {
            Destroy(customer.gameObject);
        }
    }
}
