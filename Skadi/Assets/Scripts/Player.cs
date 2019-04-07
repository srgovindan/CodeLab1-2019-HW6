using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public int x, y;
    public int xNew, yNew;//to check the cell player is moving to 
    public bool canMove;
    [Header("Keycodes")] 
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if (canMove)
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
            MovePlayerOnGrid(xNew,yNew);
        }
        else if (Input.GetKeyDown(DownKey))
        {
            yNew--;
            MovePlayerOnGrid(xNew,yNew);
        }
        else if (Input.GetKeyDown(LeftKey))
        {
            xNew--;
            MovePlayerOnGrid(xNew,yNew);
        }
        else if (Input.GetKeyDown(RightKey))
        {
            xNew++;
            MovePlayerOnGrid(xNew,yNew);
        }

    }

    public void MovePlayerOnGrid(int x, int y)
    {
        //move the player if the cell exists
        if (GridManager.GM.TileExistsOnGrid(x, y))
        {
            this.x = x;
            this.y = y;
            ResetXY();
            transform.position = new Vector3(x, 0.75f, y);
            GridManager.GM.Grid[x][y].GetComponent<Tile>().PlayerSteppedOnTile();
        }
        else
        {
            //play a sfx if can't move there
            AudioManager.AM.PlayAudioClip(1);
            ResetXY();
        }
    }

    public void PlayerFallAnimation()
    { 
        //play sfx
        AudioManager.AM.PlayAudioClip(4);
        //lerp animation
        float fallTime = 0.5f;
        Vector3.Lerp(new Vector3(x, 0.75f, y), new Vector3(x, 0.5f, y),fallTime);
    }

    void ResetXY()
    {
        xNew = x; 
        yNew = y;
    }
    
    
}
