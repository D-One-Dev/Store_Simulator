using UnityEngine;

public class WarehouseController : MonoBehaviour
{
    //префаб коробки
    [SerializeField] private GameObject[] boxes;
    //текущая коробка
    public GameObject currentBox;
    void Start()
    {
        //спавн новой коробки
        SpawnBox();
    }
    //спавн новой коробки
    public void SpawnBox()
    {
        currentBox = Instantiate(boxes[Random.Range(0, boxes.Length)], transform.position, Quaternion.identity);
    }
}
