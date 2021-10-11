using UnityEngine;

public class RoadPointController : MonoBehaviour
{
    //разрешение поля по Х и У, положение данной точки в сетке по Х и У
    [SerializeField] private int resX, resY, posX, posY;
    //список всех точек пути
    [SerializeField] private GameObject[] roadPoints;
    //точка выхода
    [SerializeField] private GameObject exitPoint;
    //двумерный массив - сетка точек передвижения покупателей
    private GameObject[,] pointsArray;
    //я не знаю что это
    private int count;
    //соседи данной точки
    public GameObject[] neighbors;
    void Start()
    {
        //задаём размер сетки
        pointsArray = new GameObject[resX, resY];
        //размещаем каждую точку пути по своим координатам
        for(int y = 0; y < resY; y++)
        {
            for (int x = 0; x < resX; x++)
            {
                pointsArray[x, y] = roadPoints[count];
                count++;
            }
        }
        //находим соседей точки
        neighbors = new GameObject[4];
        if (posX > 0) neighbors[0] = pointsArray[posX - 1, posY];
        if (posY > 0) neighbors[1] = pointsArray[posX, posY - 1];
        if (posX < resX -1) neighbors[2] = pointsArray[posX + 1, posY];
        if (posY < resY -1) neighbors[3] = pointsArray[posX, posY + 1];
    }
    //возврат новой точки пути
    public void ReturnNewPoint(GameObject customer, bool isLeaving)
    {
        //если поупатель ещё не уходит
        if(!isLeaving)
        {
            //сброс newPoint
            GameObject newPoint = null;
            //выбираем цель из списка соседей точки
            while(newPoint == null)
            {
                int rand = Random.Range(0, 4);
                if (neighbors[rand] != null) newPoint = neighbors[rand];
            }
            //возвращаем покупателю новую точку пути
            customer.GetComponent<CustomerAI>().target = newPoint;
        }
        //если покупатель уходит
        else
        {
            //сначала покупатель идёт до упора влево, затем вниз
            if(posX == 0 && posY == resY - 1) customer.GetComponent<CustomerAI>().target = exitPoint;
            if (posX > 0) customer.GetComponent<CustomerAI>().target = neighbors[0];
            else if(posY < resY - 1) customer.GetComponent<CustomerAI>().target = neighbors[3];
        }
    }
}
