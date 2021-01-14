using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : ButtonAffected
{
    

    public override void Buttoned()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.layer = LayerMask.NameToLayer("Default");
        this.GetComponent<BoxCollider>().isTrigger = true;
    }

    public override void UnBottoned()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.layer = LayerMask.NameToLayer("Gate");
        this.GetComponent<BoxCollider>().isTrigger = false;
    }

}
