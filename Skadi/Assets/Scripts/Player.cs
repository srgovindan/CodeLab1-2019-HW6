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
        //call move function on player input
        if (Input.GetKeyDown(UpKey))
        {
            MovePlayerOnGrid(x,y++);
        }
        else if (Input.GetKeyDown(DownKey))
        {
            MovePlayerOnGrid(x,y--);
        }
        else if (Input.GetKeyDown(LeftKey))
        {
            MovePlayerOnGrid(x--,y);
        }
        else if (Input.GetKeyDown(RightKey))
        {
            MovePlayerOnGrid(x++,y);
        }
    }
    public void MovePlayerOnGrid(int x, int y)
    {
        if (GridManager.GM.TileExistsOnGrid(x, y))
        {
            this.x = x;
            this.y = y;
            transform.position = new Vector3(x, 0.75f, y);
        }
        else
        {
            AudioManager.AM.PlayAudioClip(1);
        }
    }
}
