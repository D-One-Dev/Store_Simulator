using UnityEngine;

public class RoadPointsController : MonoBehaviour
{
    [SerializeField] private GameObject[] nearPoints;
    public void GiveNewPoint(GameObject customer)
    {
        customer.GetComponent<CustomerController>().target = nearPoints[Random.Range(0, nearPoints.Length)];
    }
}
