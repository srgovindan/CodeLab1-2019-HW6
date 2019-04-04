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
        if (CellExistsOnGrid(xNew,yNew))
        {
            // if the grid is not occupied, let the object move there
            if (!Grid[xNew][yNew].isOccupied)
            {
                ob.transform.position = new Vector3(xNew, 0.75f, yNew);
//        if the object is not a player, we can use this to set the cell.tileObject to a different GameObject
//        Grid[x][y].tileObject = null;
//        Grid[xNew][yNew].tileObject = ob;
                if (ob.name == "Player")
                {
                    Grid[xNew][yNew].isOccupied = true;
                    Grid[x][y].isOccupied = false;
                }
            }
        }

        // if the grid is occupied, play a little animation or sfx
        else
        {
         //TODO: play a sfx and/or animation. Use Bfxr
        }
    }

    public bool CellExistsOnGrid(int x, int y)
    {
        if (x < 0 || x > GridSizeX)
        {
            if (y < 0 || y > GridSizeY)
            {
                Debug.Log("Cell does not exist");
                return false;
            }
        }
        Debug.Log("Cell exists");
        return true;
    }
    
    //TODO: Write a function to see if all Ice Tiles are cracked 
}
