using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //скорость движения игрока
    [SerializeField] private float speed;
    //точка рук игрока, GameObject склада
    [SerializeField] private GameObject playerHands, warehouse;
    //находится ли игрок на складе
    private bool isOnWarehouse;
    //коробка
    private GameObject box;
    //находится ли игрок на складе, жив ли игрок
    public bool isOnShelf, isAlive = true;
    //Input System
    private NewInput PI;
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
        //если игрок жив
        if (isAlive)
        { 
            //считываем нажатия клавиш
            float moveX = PI.Gameplay.MoveX.ReadValue<float>();
            float moveY = PI.Gameplay.MoveY.ReadValue<float>();
            //поворот игрока
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
            //движение игрока
            Vector2 move = new Vector2(moveX * speed, moveY * speed);
            gameObject.GetComponent<Rigidbody2D>().velocity = move;
            //перемещение коробки за игрком
            if (box != null) box.transform.position = playerHands.transform.position;
        }
    }
    //всё что активируется кнопкой Е
    private void Use()
    {
        //если игрок на складе
        if (isOnWarehouse)
        {
            //взять коробку
            box = warehouse.GetComponent<WarehouseController>().currentBox;
        }
        //если игрок у полки
        if (isOnShelf)
        {
            //удалить коробку, заспавнить новую    
            Destroy(box.gameObject);
            warehouse.GetComponent<WarehouseController>().SpawnBox();
        }
        //если игрок мёртв перезапустить уровень
        if (!isAlive) SceneManager.LoadScene("Gameplay");
    }
    //потеря коробки
    private void DropBox()
    {
        if (box != null)
        {
            //удалить коробку, заспавнить новую 
            Destroy(box);
            warehouse.GetComponent<WarehouseController>().SpawnBox();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //коллизия со складом
        if (collision.gameObject.CompareTag("Warehouse")) isOnWarehouse = true;
        //столкновение с покупателем
        if (collision.gameObject.CompareTag("Customer"))
        { 
            //потеря коробки
            DropBox();
            //потеря хп
            gameObject.GetComponent<HealthController>().LooseHp();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //отход от склада
        if (collision.gameObject.CompareTag("Warehouse")) isOnWarehouse = false;
    }
}
