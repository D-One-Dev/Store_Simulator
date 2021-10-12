using UnityEngine;

public class WarehouseController : MonoBehaviour
{
    //box prefab
    [SerializeField] private GameObject[] boxes;
    //current box
    public GameObject currentBox;
    void Start()
    {
        //new box spawn
        SpawnBox();
    }
    //new box spawn
    public void SpawnBox()
    {
        currentBox = Instantiate(boxes[Random.Range(0, boxes.Length)], transform.position, Quaternion.identity);
    }
}
