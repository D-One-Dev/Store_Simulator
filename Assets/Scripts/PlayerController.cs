using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject playerHands, warehouse;
    private NewInput PI;
    private bool isOnWarehouse;
    private GameObject box;
    public bool isOnShelf, isAlive = true;
    public float rot;
    private void Awake()
    {
        PI = new NewInput();
        PI.Gameplay.Use.performed += context => Use();
    }
    private void OnEnable()
    { PI.Enable(); }
    private void OnDisable()
    { PI.Disable(); }
    void FixedUpdate()
    {
        if (isAlive)
        { 
            float moveX = PI.Gameplay.MoveX.ReadValue<float>();
            float moveY = PI.Gameplay.MoveY.ReadValue<float>();
            if(moveX != 0)
            {
                if (moveX == 1) transform.rotation = Quaternion.Euler(0, 0, -90);
                else if (moveX == -1) transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (moveY != 0)
            { 
                if(moveY == 1) transform.rotation = Quaternion.Euler(0, 0, 0);
                else if (moveY == -1) transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            Vector2 move = new Vector2(moveX * speed, moveY * speed);
            gameObject.GetComponent<Rigidbody2D>().velocity = move;
            if (box != null) box.transform.position = playerHands.transform.position;
        }
    }
    private void Use()
    {
        if (isOnWarehouse)
        {
            box = warehouse.GetComponent<WarehouseController>().currentBox;
        }
        if (isOnShelf)
        {
                Destroy(box.gameObject);
                warehouse.GetComponent<WarehouseController>().SpawnBox();
        }
        if (!isAlive) SceneManager.LoadScene("Game");
    }
    private void DropBox()
    {
        if (box != null)
        {
            Destroy(box);
            warehouse.GetComponent<WarehouseController>().SpawnBox();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Warehouse")) isOnWarehouse = true;
        if (collision.gameObject.CompareTag("Customer"))
        { 
            DropBox();
            gameObject.GetComponent<HealthController>().LooseHp();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Warehouse")) isOnWarehouse = false;
    }
}
