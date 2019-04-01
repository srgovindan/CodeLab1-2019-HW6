using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    case 'X':
                        //tile = Instantiate(BlackHole);
                        //Debug.Log("Black Hole Instantiated: " + tile.name);
                        //tile.transform.position = new Vector3(x - line.Length / 2f, inputLines.Length / 2f - y);
                        //tile.transform.SetParent(HolesManager.me.holeParent);
                        break;
                    case 'P':
                        //tile = Player;
                        //PlayerPosReset(new Vector2(x - line.Length / 2f, inputLines.Length / 2f - y));
                        break;
                    default:
                        tile = null;
                        break;
                }
            }
        }
    }
}
