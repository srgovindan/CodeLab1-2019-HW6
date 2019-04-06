using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //TODO: Consolidate Tile and Cell class
    public int x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTile(int x, int y)
    {
        transform.position = new Vector3(x, 0f, y);
    }
}
