using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    protected float duration = 3;
    protected float damageMod = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        print("I'm shield's update");
    }
    
    
    public virtual void Timer()
    {
        print("Shield Timer started");
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            print("Destroyed shield");
            Destroy(this);
        }
    }

    public virtual float ReduceDamage(float damage)
    {
        return damage * damageMod;
    }
}
