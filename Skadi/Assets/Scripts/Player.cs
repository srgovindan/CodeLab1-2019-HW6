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
//        x = 0;
//        y = 0;
//        xNew = 0;
//        yNew = 0;
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
        if (!GridManager.GM.CellExistsOnGrid(xNew,yNew))
        {
            xNew = x;
            yNew = y;
        }
        if (GridManager.GM.CellExistsOnGrid(xNew,yNew))
        {
            GridManager.GM.MoveGridObject(x,y,xNew,yNew,gameObject);
            x = xNew;
            y = yNew;
        }
    }

    public void MovePlayer(int x, int y)
    {
        transform.position = new Vector3(x, 0.75f, y);
    }
}
