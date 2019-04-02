using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager TM;
    
    public Cell[][] Grid;
    public int GridSizeX;
    public int GridSizeY;

    [Header("Tile Prefabs")] 
    public GameObject iceTile;

    [Header("Player Prefab")] 
    public GameObject player;
    
    void Start()
    {
        // SINGLETON
        if (TM == null)
        {
            DontDestroyOnLoad(gameObject);
            TM = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
       CreateGrid();
    }

    void CreateGrid()
    { 
        // Initialize Grid Array
        Grid = new Cell[GridSizeX][];
        for (int i = 0; i < GridSizeX; i++)
        {
            Grid[i] = new Cell[GridSizeY];
        }
        
        // Create grid of tiles
        for (int i = 0; i < GridSizeX; i++)
        {
            for (int j = 0; j < GridSizeY; j++)
            {
                // Create a tile at x,y 
                Grid[i][j] = CreateCell(i, j);
            }
        } 
    }

    Cell CreateCell(int x, int y)
    {
        Cell newCell = new Cell();
        newCell.x = x;
        newCell.y = y;
        return newCell;
    }

    
    public void MoveGridObject(int x, int y, int xNew, int yNew, GameObject ob)
    {
        ob.transform.position = new Vector3(xNew,0.75f,yNew);
        Grid[x][y].tileObject = null;
        Grid[xNew][yNew].tileObject = ob;
        if (ob.name == "Player")
        {
            Grid[xNew][yNew].isOccupied = true;
            Grid[x][y].isOccupied = false;
        }
    }

    
    //TODO: Write a function to see if all Ice Tiles are cracked 
}
