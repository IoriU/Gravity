using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : ButtonAffected
{
    [SerializeField] private bool once;


    public override void Buttoned()
    {
        if (once)
        {
            Destroy(this);
        }
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
