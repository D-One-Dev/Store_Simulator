using UnityEngine;

public class RoadPointController : MonoBehaviour
{
    //field X and Y definition, this point's X and Y coordinates in the grid
    [SerializeField] private int resX, resY, posX, posY;
    //list of all road points
    [SerializeField] private GameObject[] roadPoints;
    //exit point
    [SerializeField] private GameObject exitPoint;
    //2D array - customer's movement grid
    private GameObject[,] pointsArray;
    //IDK what's this
    private int count;
    //this point's neighbors
    public GameObject[] neighbors;
    void Start()
    {
        //setting the grid size
        pointsArray = new GameObject[resX, resY];
        //placing every road point on it's coordinates
        for(int y = 0; y < resY; y++)
        {
            for (int x = 0; x < resX; x++)
            {
                pointsArray[x, y] = roadPoints[count];
                count++;
            }
        }
        //finding the point's neighbors
        neighbors = new GameObject[4];
        if (posX > 0) neighbors[0] = pointsArray[posX - 1, posY];
        if (posY > 0) neighbors[1] = pointsArray[posX, posY - 1];
        if (posX < resX -1) neighbors[2] = pointsArray[posX + 1, posY];
        if (posY < resY -1) neighbors[3] = pointsArray[posX, posY + 1];
    }
    //return new point
    public void ReturnNewPoint(GameObject customer, bool isLeaving)
    {
        //if the customer is not leaving yet
        if(!isLeaving)
        {
            //newPoint reset
            GameObject newPoint = null;
            //choosing the target from the neighbors list
            while(newPoint == null)
            {
                int rand = Random.Range(0, 4);
                if (neighbors[rand] != null) newPoint = neighbors[rand];
            }
            //returning new way point
            customer.GetComponent<CustomerAI>().target = newPoint;
        }
        //if the customer is leaving
        else
        {
            //first go to the left wall, then down
            if(posX == 0 && posY == resY - 1) customer.GetComponent<CustomerAI>().target = exitPoint;
            if (posX > 0) customer.GetComponent<CustomerAI>().target = neighbors[0];
            else if(posY < resY - 1) customer.GetComponent<CustomerAI>().target = neighbors[3];
        }
    }
}
