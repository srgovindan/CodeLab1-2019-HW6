using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GridManager : MonoBehaviour
{
    public static GridManager GM;
    public GameObject[][] Grid;
    private int GridSizeX;
    private int GridSizeY;
    public static GameObject player;

    public int levelNum;
    
    [Header("Prefabs")] 
    public GameObject playerPrefab;
    public GameObject startTile;
    public GameObject goalTile;
    public GameObject iceTile;
    public GameObject groundTile;
    
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
        
        levelNum = 1;
        LoadLevel(levelNum);
    }
    public void ReloadLevel()
    {
        Grid = null;
        GameObject[] tiles =GameObject.FindGameObjectsWithTag("Tile");
        Destroy(player);
        foreach (var obj in tiles)
        {
            Destroy(obj);
        }
        GameObject[] iceTiles =GameObject.FindGameObjectsWithTag("IceTile");
        Destroy(player);
        foreach (var obj in iceTiles)
        {
            Destroy(obj);
        }
    }
    void GetLevelLayoutData(int levelIndex)
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
        //set Grid Size Y
        GridSizeY = inputLines.Length;
        for (int y = 0; y < GridSizeY; y++)
        {
            string line = inputLines[y];
            //set Grid Size X
            GridSizeX = line.Length;
        }
    }
    void CreateGrid()
    { 
        // Initialize Grid Array of GameObjects to hold Tiles
        Grid = new GameObject[GridSizeX][];
        for (int i = 0; i < GridSizeX; i++)
        {
            Grid[i] = new GameObject[GridSizeY];
        }
    }
    void LoadLevelObjects(int levelIndex)
    {
        // hold the level file path in a string
        string filePath = Application.dataPath + "/level" + levelIndex + ".txt";
        // if the level file does not exist, create it
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "@x#*");
        }
        // reading from file
        string[] inputLines = File.ReadAllLines(filePath);
        //set Grid Size Y
        GridSizeY = inputLines.Length;
        for (int y = 0; y < GridSizeY; y++)
        {
            string line = inputLines[y];
            //set Grid Size X
            GridSizeX = line.Length;
            for (int x = 0; x < GridSizeX; x++)
            {
                // create an empty tile GameObject
                GameObject tile;
                switch (line[x])
                {
                    case '*':
                        //load a goal tile prefab
                        tile = Instantiate(goalTile);
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y] = tile;
                        break;
                    case '#':
                        //load a ground tile prefab
                        tile = Instantiate(groundTile);
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y] = tile;
                        break;
                    case 'x':
                        //load an ice tile prefab
                        tile = Instantiate(iceTile);
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y] = tile;
                        break;
                    case '@':
                        //load a start tile prefab
                        tile = Instantiate(startTile);
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        Grid[x][y] = tile;
                        //move player to that grid coord
                        player = Instantiate(playerPrefab);   
                        player.GetComponent<Player>().MovePlayerOnGrid(x,y);
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
    
    //public wrapper function to load a level from an ascii file
    public void LoadLevel(int i)
    {
        ReloadLevel();
        GetLevelLayoutData(i);
        CreateGrid();
        LoadLevelObjects(i);
        //play start tile sfx
        AudioManager.AM.PlayAudioClip(2);
    }

    public bool TileExistsOnGrid(int x, int y)
    {
        //no tile outside grid boundaries
        if (x < 0 || x > GridSizeX-1 || y < 0 || y > GridSizeY-1)
        {
            //Cell does not exist
            return false;
        }
        //no tile within the grid boundaries
        if (Grid[x][y] == null)
        {
            //Cell does not exist
            return false;
        }
        //Cell exists
        return true;
    }
    public bool CheckIfAllIceTilesCracked()
    {
        //get all the tiles, set count to 0
        int numTilesCracked = 0;
        GameObject[] iceTiles = GameObject.FindGameObjectsWithTag("IceTile");
        foreach (var tile in iceTiles)
        {
            if (tile.GetComponent<IceTile>().tileCracked)
            {
                numTilesCracked++;
            }
        }
        Debug.Log(numTilesCracked);
        //if all tiles are cracked
        if (numTilesCracked == iceTiles.Length)
        {
            return true;
        }
        return false;
    }
    public IEnumerator DelayedLoadLevel(float f)
    {
        yield return new WaitForSeconds(f);
        LoadLevel(levelNum);
    }
}
