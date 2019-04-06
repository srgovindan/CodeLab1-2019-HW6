using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //TODO: Consolidate Tile and Cell class
    public int x, y;
    public void MoveTile(int x, int y)
    {
        transform.position = new Vector3(x, 0f, y);
    }
}
