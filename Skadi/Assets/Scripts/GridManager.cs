using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GridManager : MonoBehaviour
{

    public static GridManager GM;
    
    public Cell[][] Grid;
    public int GridSizeX;
    public int GridSizeY;

    [Header("Prefabs")] 
    public GameObject iceTile;
    public GameObject player;
    
    void Start()
    {
        // SINGLETON
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
       CreateGrid();
       LoadLevel(1);
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
        // if the cell exists on the grid and is within the grid bounds
        if (CellExistsOnGrid(xNew,yNew))
        {
            // if the cell has a tile, let the object move there
            if (Grid[xNew][yNew].cellHasTile)
            {
                ob.transform.position = new Vector3(xNew, 0.75f, yNew);
//                if (ob.name == "Player")
//                {
////                    Grid[xNew][yNew].isOccupied = true;
////                    Grid[x][y].isOccupied = false;
//                }
            }
        }
        // if the grid is occupied or is out of bounds, play a little animation or sfx
        if(!CellExistsOnGrid(xNew,yNew))
        {
            Debug.Log("Playing audio");
            AudioManager.AM.PlayAudioClip(0);
        }
    }

    public bool CellExistsOnGrid(int x, int y)
    {
        if (x < 0 || x > GridSizeX-1 || y < 0 || y > GridSizeY-1)
        {
                Debug.Log("Cell does not exist");
                return false;
        }
        Debug.Log("Cell exists");
        return true;
    }
    
    //TODO: Write a function to see if all Ice Tiles are cracked 
    
     /// <summary>
    /// Takes an int number input and loads the corresponding level from a text file.
    /// Levels are currently loaded up side down when seen on the Ascii file.
    /// </summary>
    public void LoadLevel(int levelIndex)
    {
        // hold the level file path in a string
        string filePath = Application.dataPath + "/level" + levelIndex + ".txt";
        // if the level file does not exist, create it
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "X");
        }
        // reading from file
        string[] inputLines = File.ReadAllLines(filePath);
        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
            for (int x = 0; x < line.Length; x++)
            {
                // create an empty tile GameObject
                GameObject tile;
                switch (line[x])
                {
                    case '*':
                        //load a goal tile prefab
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/GoalTile"));
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y].cellHasTile = true;
                        break;
                    case 'x':
                        //load an ice tile prefab
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/IceTile"));
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y].cellHasTile = true;
                        break;
                    case '@':
                        //load a start tile prefab
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/StartTile"));
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y].cellHasTile = true;
                        //move player to that grid coord
                        GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));                 
                        //GameObject player = GameObject.Find("Player");                 
                        player.GetComponent<Player>().MovePlayer(x,y);
                        break;
                    case '.':
                        //null the cell object when there is supposed to be an empty space
                        Grid[x][y] = null;
                        break;
                    default:
                        tile = null;
                        break;
                }
            }
        }
    }
     
}
