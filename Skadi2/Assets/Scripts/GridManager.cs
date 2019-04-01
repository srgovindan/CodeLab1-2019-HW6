using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GridManager : MonoBehaviour
{

    public static GridManager GM;
    public int levelNum;
    
    [Header("Tile Prefabs")] 
    public GameObject iceTile;
    public GameObject startTile;
    public GameObject goalTile;
    [Header("Player Prefab")] 
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

        //Load first level
        levelNum = 1;
        LoadLevel(1);
    }
    
    /// <summary>
    /// Takes an int number input and loads the corresponding level from a text file.
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
                GameObject tile;
                //create tiles based on ascii
                switch (line[x])
                {
                    case 'P':
                        tile = Instantiate(iceTile);
                        tile.AddComponent<StartTile>();
                        tile.transform.position = new Vector3(x - line.Length / 2f,0f, inputLines.Length / 2f - y);
                        //create and set player pos
                        GameObject playerObject = Instantiate(player);
                        
                        playerObject.transform.position =  new Vector3(x - line.Length / 2f,.75f, inputLines.Length / 2f - y);
                        break;
                    case 'x':
                        tile = Instantiate(iceTile);
                        tile.AddComponent<IceTile>();
                        tile.transform.position = new Vector3(x - line.Length / 2f,0f, inputLines.Length / 2f - y);
                        break;
                    case 'G':
                        tile = Instantiate(iceTile);
                        tile.AddComponent<GoalTile>();
                        tile.transform.position = new Vector3(x - line.Length / 2f,0f, inputLines.Length / 2f - y);
                        break; 
                }
            }
        }
    }
    
}
