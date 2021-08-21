using UnityEngine;

public class ShelfController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public string shelfColor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(shelfColor)) player.GetComponent<PlayerController>().isOnShelf = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(shelfColor)) player.GetComponent<PlayerController>().isOnShelf = false;
    }
}
