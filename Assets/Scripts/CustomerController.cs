using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [SerializeField] private GameObject[] RoadPoints;
    [SerializeField] private float smoothness;
    public GameObject target;
    void Start()
    {
        transform.position = RoadPoints[Random.Range(0, RoadPoints.Length)].transform.position;
    }
    void FixedUpdate()
    {
        if (target != null)
        { 
            float moveX = Mathf.Lerp(transform.position.x, target.transform.position.x, smoothness);
            float moveY = Mathf.Lerp(transform.position.y, target.transform.position.y, smoothness);
            transform.position = new Vector3(moveX, moveY, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RoadPoint")) collision.GetComponent<RoadPointsController>().GiveNewPoint(gameObject);
    }
}
