using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public Vector3[,] grid;
    public int gridLength;
    public int gridWidth;
    public float gridScale;
    public GameObject gridObject;

    void Awake()
    {
        grid = new Vector3[gridWidth, gridLength];

        CreateGridStructure();
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridLength; j++)
            {
                Instantiate(gridObject, grid[i, j], Quaternion.identity, transform);
            }
        }
    }

    public void Update()
    {
        if (gridWidth != grid.GetLength(0) || 
            gridLength != grid.GetLength(1)  ) 
        {
            for (int i = 0; i < transform.childCount; i++)
            { 
                Destroy(gameObject.transform.GetChild(i).gameObject); 
            }
            
            
            Awake();
        }
    }

    public void CreateGridStructure()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridLength; j++)
            {
                grid[i, j] = new Vector3(i * gridScale, 0, j * gridScale);
            }
        }
    }
}
