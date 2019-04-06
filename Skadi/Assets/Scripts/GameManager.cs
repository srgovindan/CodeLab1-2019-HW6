using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
                // create an empty tile GameObject
                GameObject tile;
                switch (line[x])
                {
                    case '*':
                        //load a goal tile prefab
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/GoalTile"));
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        break;
                    case 'x':
                        //load an ice tile prefab
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/IceTile"));
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        break;
                    case '@':
                        //load a start tile prefab
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/StartTile"));
                        tile.GetComponent<Tile>().MoveTile(x,y);
                        //move player to that grid coord
                        GameObject player = GameObject.Find("Player");                 
                        player.GetComponent<Player>().MovePlayer(x,y);
                        break;
                    default:
                        tile = null;
                        break;
                }
            }
        }
    }
}
