using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : ButtonAffected
{
    [SerializeField] private bool isButtoned;
    [SerializeField] private bool isAlways;
    [SerializeField] private bool clockwise;
    [SerializeField] private float speed;
    [SerializeField] private float startRot;
    [SerializeField] private float destination;
    [SerializeField] private float endRot;

    private void Start()
    {
        startRot = transform.eulerAngles.z;
        StartCoroutine("SpinAlways", clockwise);
    }

    public override void Buttoned()
    {
        isButtoned = true;
        if (!isAlways)
        {
            destination = endRot;
            StopCoroutine("SpinDestination");
            StartCoroutine("SpinDestination", clockwise);
        }
        else
        {
            StartCoroutine("SpinAlways", clockwise);
        }
    }

    public override void UnBottoned()
    {
        isButtoned = false;
  
        if (!isAlways)
        {
            destination = startRot;
            StopCoroutine("SpinDestination");
            StartCoroutine("SpinDestination", !clockwise);
        } 
    }

    IEnumerator SpinDestination(bool clockwise)
    {
        float diff = destination - transform.eulerAngles.z;
        while (!(diff > -0.1 && diff < 0.1))
        {
            if (clockwise)
            {

                this.gameObject.transform.Rotate(new Vector3(0f, 0f, -speed));
            }
            else
            {
                this.gameObject.transform.Rotate(new Vector3(0f, 0f, speed));
            }
            yield return new WaitForFixedUpdate();
            diff = destination - transform.eulerAngles.z;
        }
    }

    IEnumerator SpinAlways(bool clockwise)
    {
   
        while (isButtoned && isAlways)
        {

            if (clockwise)
            {
                
                this.gameObject.transform.Rotate(new Vector3(0f, 0f, -speed));
            }
            else
            {
                this.gameObject.transform.Rotate(new Vector3(0f, 0f, speed));
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
