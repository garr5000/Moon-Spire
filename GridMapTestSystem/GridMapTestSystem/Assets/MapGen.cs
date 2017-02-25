using System.Collections.Generic;
using UnityEngine;


public class MapGen : MonoBehaviour
{

    public GameObject defaultTile;
    private List <Vector3> gridPositions = new List<Vector3>();
    private Transform boardHolder;
    void createList()
    {
        gridPositions.Clear();
        for(int x =0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void boardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for(int x=0;x<10;x++)
        {
            for(int y = 0; y < 10; y++)
            {
                GameObject instantiateObj = defaultTile;
                GameObject instance = Instantiate(instantiateObj, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }

    }

    public void createGrid()
    {
        boardSetup();
        createList();
    }
    void Start()
    {
    }
}