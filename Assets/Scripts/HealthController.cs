using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    //����� ���������, ����� � ��
    [SerializeField] private Text gameOver, healthTxt;
    //���-�� ��
    private int health = 3;
    //������ ��
    public void LooseHp()
    {
        //�������� ��
        health -= 1;
        //������ �����
        healthTxt.text = "Health: " + health.ToString();
        //������
        if (health == 0)
        {
            //��������� ������ ������
            gameObject.GetComponent<PlayerController>().isAlive = false;
            //���������� ������ velocity ����� �� �� ���� �� ����� (�� ��������)
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //���������� ����� ���������
            gameOver.enabled = true;
        }
    }
}
