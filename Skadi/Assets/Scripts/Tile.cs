using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
    public void MoveTile(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.position = new Vector3(x, 0f, y);
    }
}