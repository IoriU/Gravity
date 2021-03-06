﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ButtonAffected
{
    [SerializeField] private float posNow;
    [SerializeField] private float posStart;
    [SerializeField] private float posFinal;
    [SerializeField] private float destination;
    [SerializeField] private float speed;
    [SerializeField] private bool isAlways;
    [SerializeField] private bool horizontal;
    [SerializeField] private bool isRepeat;
    public float diff;

    private void Start()
    {

        if (horizontal)
        {
            posNow = transform.position.x;
        }
        else
        {
            posNow = transform.position.y;
            
        }
        posStart = posNow;
        destination = posFinal;
        if (isAlways)
            StartCoroutine(MoveObject());
        
        
    }


    public override void Buttoned()
    {
        destination = posFinal;
        StopCoroutine("MoveObject");
        StartCoroutine("MoveObject");
    }

    public override void UnBottoned()
    {
        destination = posStart;
        StopCoroutine("MoveObject");
        StartCoroutine("MoveObject");
    }

    IEnumerator MoveObject()
    {
        
        while (true)
        {
            //float diff = destination - posNow;

            diff = destination - posNow;
            while (!(diff > -0.1 && diff < 0.1))
            {
                Vector3 temp = transform.position;
                if (posNow < destination)
                {
                    posNow += speed;
                }
                else if (posNow > destination)
                {
                    posNow -= speed;
                }
                if (horizontal)
                {
                    temp.x = posNow;
                }
                else
                {
                    temp.y = posNow;
                }
                transform.position = temp;
                diff = destination - posNow;
                yield return new WaitForFixedUpdate();
            }
            if (isRepeat)
            {

                destination = posStart;
                posStart = posFinal;
                posFinal = destination;

            } 
            else
            {
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
