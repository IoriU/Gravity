using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : ButtonAffected
{
    enum TYPE {EXPLODE, CLICKAREA};
    [SerializeField] private TYPE thisType;
    public override void Buttoned()
    {
        if (thisType == TYPE.EXPLODE)
        {
            Destroy(this.gameObject);
        }
        else if (thisType == TYPE.CLICKAREA)
        {
            this.gameObject.GetComponent<ClickableArea>().ToogleArea();
            Destroy(this);
        }
    }


    public override void UnBottoned()
    {
        ;
    }
}

