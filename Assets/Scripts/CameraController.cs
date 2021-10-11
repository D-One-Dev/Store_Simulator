using UnityEngine;

public class CameraController : MonoBehaviour
{
    //GameObject игрока
    [SerializeField] private GameObject player;
    //степень плавности движения камеры
    [SerializeField] private float smoothness;
    void FixedUpdate()
    {
        // получаю сглаженное значение для движения камеры
        float moveX = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothness);
        float moveY = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothness);
        //двигаю камеру
        transform.position = new Vector3(moveX, moveY, transform.position.z);
    }
}
