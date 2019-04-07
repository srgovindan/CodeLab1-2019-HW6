using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public int x, y;
    public int xNew, yNew;//to check the cell player is moving to 
    [Header("Keycodes")] 
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;

    void Update()
    {
        if (Input.anyKey)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        //check for player input
        if (Input.GetKeyDown(UpKey))
        {
            yNew++;
        }
        else if (Input.GetKeyDown(DownKey))
        {
            yNew--;
        }
        else if (Input.GetKeyDown(LeftKey))
        {
            xNew--;
        }
        else if (Input.GetKeyDown(RightKey))
        {
            xNew++;
        }
        
        //move the player if the cell exists
        if (GridManager.GM.TileExistsOnGrid(xNew, yNew))
        {
            MovePlayerOnGrid(xNew,yNew);
        }
        else
        {
            //play a sfx if can't move there
            AudioManager.AM.PlayAudioClip(1);
            ResetXY();
        }
    }

    public void MovePlayerOnGrid(int x, int y)
    {
        this.x = x;
        this.y = y;
        ResetXY();
        transform.position = new Vector3(x, 0.75f, y);
        GridManager.GM.Grid[x][y].GetComponent<Tile>().PlayerSteppedOnTile();
    }

    void ResetXY()
    {
        xNew = x; 
        yNew = y;
    }
}
