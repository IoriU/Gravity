using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : ButtonAffected
{
    
    [SerializeField] private float scale;
    [SerializeField] private float lowerBound;
    [SerializeField] private float upperBound;
    [SerializeField] private bool forward;
    [SerializeField] private bool isButtoned;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private bool isPositive;
    [SerializeField] private bool always;
    [SerializeField] private bool once;
    public void SetScale(float scale)
    {
        this.scale = scale;
    }

    private void Start()
    {

        if (isHorizontal)
        {
            this.scale = transform.localScale.x;
        }
        else
        {
            this.scale = transform.localScale.y;
        }
        StartCoroutine(AutoRezize());
    }

    /// <summary>
    ///  Resize object while maintain position.
    /// </summary>
    public void ResizeObject()
    {


   
        if (isHorizontal && transform.localScale.x != scale)
        {

            Vector3 temp = transform.localScale;
            temp.x = scale;
            float dif = transform.localScale.x - temp.x;
            Vector3 pos = transform.position;
            if (isPositive)
            {
                pos.x -= dif / 2;
            }
            else
            { 
                pos.x += dif / 2;
            }
            transform.position = pos;
            transform.localScale = temp;


        }
        else if (!isHorizontal && transform.localScale.y != scale)
        {
            Vector3 temp = transform.localScale;
            temp.y = scale;
            float dif = transform.localScale.y - temp.y;
            Vector3 pos = transform.position;
            if (isPositive)
            {
                pos.y -= dif / 2;
            }
            else
            {
                pos.y += dif / 2;
            }
            transform.position = pos;
            transform.localScale = temp;
        }
    }

    IEnumerator AutoRezize()
    {
        while(always)
        {
            
          
            if (forward && (scale - upperBound) < 0)
            {
                scale += 0.1f;
            }
            else if (forward && (scale - upperBound) >= 0)
            {
                forward = false;
            }
            else if ((scale - lowerBound) <= 0)
            {
                forward = true;
            }
            else
            {
                scale -= 0.1f;
            }
            // Move root position 
            ResizeObject();
            yield return new WaitForFixedUpdate();
        }

        while (isButtoned)
        {

            if (forward && (scale - upperBound) < 0)
            {
                scale += 0.1f;
            }
            else if (forward && (scale - upperBound) >= 0)
            {
                ;   
            }
            else if ((scale - lowerBound) <= 0)
            {
                ;
            }
            else
            {
                scale -= 0.1f;
            }   

            // Move root position 
            ResizeObject(); 
            yield return new WaitForFixedUpdate();

        }
    }

    public override void Buttoned()
    {
        forward = true;
    }

    public override void UnBottoned()
    {
        if (once)
            return;
        forward = false;
    }
}
