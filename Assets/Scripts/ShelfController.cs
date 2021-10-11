using UnityEngine;

public class ShelfController : MonoBehaviour
{
    //GameObject игрока
    [SerializeField] private GameObject player;
    //цвет полки
    public string shelfColor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //игрок подошёл к полке
        if (collision.gameObject.CompareTag(shelfColor)) player.GetComponent<PlayerController>().isOnShelf = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //игрок отошёл от полки
        if (collision.gameObject.CompareTag(shelfColor)) player.GetComponent<PlayerController>().isOnShelf = false;
    }
}
