using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : IceTile
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(173, 63, 55);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
