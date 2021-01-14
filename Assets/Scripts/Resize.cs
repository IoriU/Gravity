using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    
    [SerializeField] private float scale;
    [SerializeField] private float lowerBound;
    [SerializeField] private float upperBound;
    [SerializeField] private bool forward;

    [SerializeField] private bool isHorizontal;
    [SerializeField] private bool isPositive;
    [SerializeField] private bool always;

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
            if (scale < upperBound && forward)
            {
                scale += 0.1f;
            }
            else if (scale > upperBound && forward)
            {
                forward = false;
            }
            else if (scale < lowerBound)
            {
                forward = true;
            }
            else
            {
                scale -= 0.1f;
            }
            ResizeObject();
            yield return new WaitForFixedUpdate();
        }
        
    }
}
