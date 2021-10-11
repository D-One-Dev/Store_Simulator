using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    //������ ����������
    [SerializeField] private GameObject customerPrefab;
    //���������� � ������������ �������� ������ ����������
    [SerializeField] private float minCD, maxCD;
    //������ � ����� �� ���������� ������
    public float timer, resetTime;
    //������ ����� ����
    public GameObject firstRoadPoint;
    void Start()
    {
        //�������� ��������� ����� ��������
        resetTime = Random.Range(minCD, maxCD);
    }
    void FixedUpdate()
    {
        //���� �������
        timer += Time.fixedDeltaTime;
        //����� ������ ����������
        if(timer >= resetTime)
        {
            //�������� ������ GameObject
            GameObject newCustomer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
            //������� ���������� ������ ����� ��������
            newCustomer.GetComponent<CustomerBody>().target = firstRoadPoint;
            //�������� ��������� ����� ��������
            resetTime = Random.Range(minCD, maxCD);
            //���������� ������
            timer = 0f;
        }
    }
}
