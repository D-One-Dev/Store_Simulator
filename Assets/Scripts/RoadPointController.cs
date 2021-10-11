using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPointController : MonoBehaviour
{
    [SerializeField] private int resX, resY, posX, posY;
    [SerializeField] private GameObject[] roadPoints;
    [SerializeField] private GameObject exitPoint;
    private GameObject[,] pointsArray;
    private int count;
    public GameObject[] neighbors;
    void Start()
    {
        pointsArray = new GameObject[resX, resY];
        for(int y = 0; y < resY; y++)
        {
            for (int x = 0; x < resX; x++)
            {
                pointsArray[x, y] = roadPoints[count];
                count++;
            }
        }
        neighbors = new GameObject[4];
        if (posX > 0) neighbors[0] = pointsArray[posX - 1, posY];
        if (posY > 0) neighbors[1] = pointsArray[posX, posY - 1];
        if (posX < resX -1) neighbors[2] = pointsArray[posX + 1, posY];
        if (posY < resY -1) neighbors[3] = pointsArray[posX, posY + 1];
    }
    public void ReturnNewPoint(GameObject customer, bool isLeaving)
    {
        if(!isLeaving)
        {
            GameObject newPoint = null;
            while(newPoint == null)
            {
                int rand = Random.Range(0, 4);
                if (neighbors[rand] != null) newPoint = neighbors[rand];
            }
            customer.GetComponent<CustomerAI>().target = newPoint;
        }
        else
        {
            if(posX == 0 && posY == resY - 1) customer.GetComponent<CustomerAI>().target = exitPoint;
            if (posX > 0) customer.GetComponent<CustomerAI>().target = neighbors[0];
            else if(posY < resY - 1) customer.GetComponent<CustomerAI>().target = neighbors[3];
        }
    }
}
