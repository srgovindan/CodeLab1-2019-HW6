using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public static TileManager instance;
    
    public Tile[][] Grid;
    public int GridSizeX;
    public int GridSizeY;

    [Header("Tile Prefabs")] 
    public GameObject iceTile;
    public GameObject iceTileCracked;
    public GameObject goalTile;
    public GameObject wallTile;
    
    void Start()
    {
        // SINGLETON
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
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
        Grid = new Tile[GridSizeX][];
        for (int i = 0; i < GridSizeX; i++)
        {
            Grid[i] = new Tile[GridSizeY];
        }
        
        // Create grid of tiles
        for (int i = 0; i < GridSizeX; i++)
        {
            for (int j = 0; j < GridSizeY; j++)
            {
                // Create a tile at x,y 
                Grid[i][j] = CreateTile(i, j);
            }
        } 
    }

    Tile CreateTile(int x, int y)
    {
        Tile newTile = new Tile();
        newTile.x = x;
        newTile.y = y;
        
        newTile.tileObject = Instantiate(iceTile);
        newTile.tileObject.transform.position = new Vector3(x*1f,0f, y*1f);
        return newTile;
    }
    

    
    //TODO: Write a function to see if all Ice Tiles are cracked 
}
