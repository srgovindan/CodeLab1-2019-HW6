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
    
    
    
    void Start()
    {
        //set inital player position
        x = 0;
        y = 0;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetKeyDown(UpKey))
        {
            y++;
        }
        if (Input.GetKeyDown(DownKey))
        {
            y--;
        }
        if (Input.GetKeyDown(LeftKey))
        {
            x--;
        }
        if (Input.GetKeyDown(RightKey))
        {
            x++;
        }
        TileManager.instance.MoveObject(x,y,gameObject);
    }
}
