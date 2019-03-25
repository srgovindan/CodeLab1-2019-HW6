using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShield : Shield
{

    public float superDuration = 5;

    // Start is called before the first frame update
    void Start()
    {
        duration = 2;
        damageMod = .25f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        print("I'm Supershield's update");
    }

    public override void Timer()
    {
        if (superDuration > 0)
        {
            superDuration -= Time.deltaTime;
            print("Using Super duration");
        }
        else
        {
            base.Timer(); //calling the superclass' function
            print("Using base Timer");
        }
    }

    public override float ReduceDamage(float damage)
    {
        if (superDuration > 0)
        {
            return 0;
        }
        return base.ReduceDamage(damage);
    }
}
