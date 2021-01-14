using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : Gravity
{
    
    [SerializeField] private float time;


    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if (isDefault)
        {
            ;
        }
        else if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override Vector3 Calculate(Vector3 direction, float force)
    {
        return direction.normalized * force;
    }

}
