using UnityEngine;

public class CameraController : MonoBehaviour
{
    //player GameObject
    [SerializeField] private GameObject player;
    //camera move smoothness
    [SerializeField] private float smoothness;
    void FixedUpdate()
    {
        //getting smoothed position
        float moveX = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothness);
        float moveY = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothness);
        //moving the camera
        transform.position = new Vector3(moveX, moveY, transform.position.z);
    }
}
