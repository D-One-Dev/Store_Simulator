using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float smoothness;
    void FixedUpdate()
    {
        float moveX = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothness);
        float moveY = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothness);
        transform.position = new Vector3(moveX, moveY, transform.position.z);
    }
}
