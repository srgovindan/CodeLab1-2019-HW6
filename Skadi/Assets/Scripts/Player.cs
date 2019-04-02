using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int x, y,xOld,yOld;

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
        xOld = 0;
        yOld = 0;
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
        GridManager.TM.MoveGridObject(xOld,yOld,x,y,gameObject);
        xOld = x;
        yOld = y;

    }
}
