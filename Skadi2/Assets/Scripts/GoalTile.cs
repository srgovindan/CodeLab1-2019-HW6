using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTile : IceTile
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(250, 114, 104);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
