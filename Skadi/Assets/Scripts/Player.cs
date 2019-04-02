using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int x, y,xNew,yNew;

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
        xNew = 0;
        yNew = 0;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
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
        if (GridManager.TM.CellExistsOnGrid(x,y))
        {
            GridManager.TM.MoveGridObject(x,y,xNew,yNew,gameObject);
            x = xNew;
            y = yNew;
        }
//        else
//        {
//            xNew = x;
//            yNew = y;
//        }
    }
}
