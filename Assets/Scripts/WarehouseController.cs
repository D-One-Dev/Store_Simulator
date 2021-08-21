using UnityEngine;

public class WarehouseController : MonoBehaviour
{
    [SerializeField] private GameObject[] boxes;
    public GameObject currentBox;
    void Start()
    {
        SpawnBox();
    }
    public void SpawnBox()
    {
        currentBox = Instantiate(boxes[Random.Range(0, boxes.Length)], transform.position, Quaternion.identity);
    }
}
