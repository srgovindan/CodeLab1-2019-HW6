using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public int x, y;
    [Header("Keycodes")] 
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //check for player input
        if (Input.GetKeyDown(UpKey))
        {
            y++;
        }
        else if (Input.GetKeyDown(DownKey))
        {
            y--;
        }
        else if (Input.GetKeyDown(LeftKey))
        {
            x--;
        }
        else if (Input.GetKeyDown(RightKey))
        {
            x++;
        }

        //move the player if the cell exists
        if (GridManager.GM.TileExistsOnGrid(x, y))
        {
            MovePlayerOnGrid(x,y);
        }
        else
        {
            //play a sfx
            AudioManager.AM.PlayAudioClip(1);
        }
    }

    public void MovePlayerOnGrid(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.position = new Vector3(x, 0.75f, y);
    }
}
