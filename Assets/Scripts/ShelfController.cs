using UnityEngine;

public class ShelfController : MonoBehaviour
{
    //player GameObject
    [SerializeField] private GameObject player;
    //shelf color
    public string shelfColor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player comes to the shelf
        if (collision.gameObject.CompareTag(shelfColor)) player.GetComponent<PlayerController>().isOnShelf = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //player goes away from the shelf
        if (collision.gameObject.CompareTag(shelfColor)) player.GetComponent<PlayerController>().isOnShelf = false;
    }
}
